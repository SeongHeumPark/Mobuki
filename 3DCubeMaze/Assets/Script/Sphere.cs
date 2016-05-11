using UnityEngine;
using System.Collections;

public class Sphere: MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject sphereCamera;
    public GameObject uiCamera;
    public GameObject standard_Cube;
    public GameObject sphere;

    public Camera UICamera;

    enum CameraSpin
    {
        UP = 0,
        RIGHT,
        DOWN,
        LEFT,
        PUSH,
        DEFAULT
    }

    public bool pushCheck = false;
	public float moveCheckTime = 0f;
    public int spinAngle = 0;
    public bool spinCheck = false;
    public int spinType = (int)CameraSpin.UP;

    public void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        sphereCamera = GameObject.Find("Sphere_Camera");
        standard_Cube = GameObject.Find("Standard_Cube");
        uiCamera = GameObject.Find("UICamera");

		sphereCamera.camera.enabled = false;

        Debug.Log(mainCamera);
        Debug.Log(sphereCamera);
        Debug.Log(standard_Cube);
        Debug.Log(uiCamera);
    }

    public void Update()
    {
        // 클릭 체크
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = UICamera.ScreenPointToRay(Input.mousePosition);
            GameObject target = RayCasting(ray);
      	}

        // 카메라 스핀
        if (spinCheck)
        {
            int angle = (int)(150f * Time.deltaTime);
            if (angle != 2)
                angle = 2;
            spinAngle += angle;

            Debug.Log(spinAngle);
            if (spinAngle >= 0 && spinAngle <= 90)
            {
                Debug.Log("Angle Add");
                MainCameraSpin(spinType, angle);
                
				if (spinAngle == 90)
				{
					Debug.Log("Angle 90");
					spinCheck = false;
					spinAngle = 0;
				}
            }
        }

        // push 를 누르면
        if (pushCheck)
        {
            Debug.Log("moveCheck");
            moveCheckTime += Time.deltaTime;

            // 시간을 정해 일정 시간이 흘르면 속도를 체크
            if (moveCheckTime > 2f)
            {
                Debug.Log("SphereStop");
                // 속도가 일정 이하일 때 정지!!!!!
                if (rigidbody.velocity.magnitude < 0.3f)
                {
                    Debug.Log("SphereStopStop");
                    moveCheckTime = 0f;
                    SphereStop();
                }
            }
        }

		if(moveCheckTime >= 5.0f) {
			Debug.Log("gameEnd");
			SphereStop();
			GameStateMgr.Instance.Lose();
		}
    }

    public void SphereStop()
    {
        MainCameraChange();
        rigidbody.useGravity = false;
        pushCheck = false;
        rigidbody.isKinematic = true;
        rigidbody.inertiaTensorRotation = Quaternion.identity;
    }

    public GameObject RayCasting(Ray ray)
    {
        Debug.Log("Ray");
        RaycastHit hitObj;
        GameObject target = null;

        if (Physics.Raycast(ray, out hitObj, 100 ) )
        {
            Debug.Log("RayCheck");

            target = hitObj.collider.gameObject;
        }
        return target;
    }

    public int ObjectNameCheck(GameObject target)
    {
        if (target == null)
            return (int)CameraSpin.DEFAULT;

        if (target.name.Equals("Push"))
        {
            Debug.Log("Push");
			target = null;
            return (int)CameraSpin.PUSH;
        }

        else if (target.name.Equals("Up"))
        {
            Debug.Log("Up");
			target = null;
            return (int)CameraSpin.UP;
        }

        else if (target.name.Equals("Right"))
        {
            Debug.Log("Right");
			target = null;
            return (int)CameraSpin.RIGHT;
        }

        else if (target.name.Equals("Down"))
        {
            Debug.Log("Down");
            return (int)CameraSpin.DOWN;
        }

        else if (target.name.Equals("Left"))
        {
            Debug.Log("Left");
			target = null;
            return (int)CameraSpin.LEFT;
        }
        return (int)CameraSpin.DEFAULT;
    }

    public void MainCameraSpin(int num, int angle)
    {
        switch (num)
        {
            case (int)CameraSpin.UP:
                {
                    standard_Cube.transform.RotateAround(Vector3.zero, Vector3.right, angle);
                    SphereReverseSpin(-sphere.transform.right, angle);
                } break;

            case (int)CameraSpin.RIGHT:
                {
                    standard_Cube.transform.RotateAround(Vector3.zero, Vector3.down, angle);
                    SphereReverseSpin(sphere.transform.up, angle);
                } break;

            case (int)CameraSpin.DOWN:
                {
                    standard_Cube.transform.RotateAround(Vector3.zero, Vector3.left, angle);
                    SphereReverseSpin(sphere.transform.right, angle);
                } break;

            case (int)CameraSpin.LEFT:
                {
                    standard_Cube.transform.RotateAround(Vector3.zero, Vector3.up, angle);
                    SphereReverseSpin(-sphere.transform.up, angle);
                } break;
        }
    }

    public void SphereReverseSpin(Vector3 standard, int angle)
    {
        Vector3 temp = sphere.transform.position;
        sphere.transform.position = Vector3.zero;
        sphere.transform.RotateAround(Vector3.zero, standard, angle);
        sphere.transform.position = temp;
    }

    // 카메라 전환
    public void MainCameraChange()
    {
        mainCamera.camera.enabled = true;
        uiCamera.camera.enabled = true;

        sphereCamera.camera.enabled = false;        
    }
    public void SphereCameraChange()
    {
        mainCamera.camera.enabled = false;
        uiCamera.camera.enabled = false;

        sphereCamera.camera.enabled = true;
    }

    public void OnTriggerEnter(Collider Object)
    {
        CubeSingleton.Instance.TeleportCheck(Object.gameObject, sphere);
    }

    public void OnTriggerExit(Collider Object)
    {
		CubeSingleton.Instance.ChangeTeleportCheck (true);
		CubeSingleton.Instance.GameClearCheck (Object.gameObject);
    }
}
