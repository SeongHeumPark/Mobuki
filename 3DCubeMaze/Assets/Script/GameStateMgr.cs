using UnityEngine;
using System.Collections;

public class GameStateMgr : MonoBehaviour {

    static private GameStateMgr instance;

    static public GameStateMgr Instance {
        get {
            if ( instance == null ) {
                instance = FindObjectOfType( typeof( GameStateMgr ) ) as GameStateMgr;

                if ( instance == null ) {
                    instance = new GameObject( "TimeMgr", typeof( GameStateMgr ) ).GetComponent<GameStateMgr>();
                }
            }

            return instance;
        }
    }

    public void Awake ( ) {
        var buttons = GetComponents<OneButton>() as OneButton[];

        foreach ( var obj in buttons ) {
            obj.enabled = false;
        }
    }

    public MapManager mapM = null;
    public Sphere sphere = null;

    public void Win() {
		Debug.Log ("Win!!");
        TimeMgr.Instance.ResetTime();
		CubeSingleton.Instance.stageNum = 0;
		CubeSingleton.Instance.nextCheck = false;
		CubeSingleton.Instance.startCheck = false;
		Application.LoadLevel(1);
    }

	public void Lose()
	{
		Debug.Log ("Lose!!");
		TimeMgr.Instance.ResetTime();
		sphere.MainCameraChange();
		CubeSingleton.Instance.stageNum = 0;
		CubeSingleton.Instance.nextCheck = false;
		CubeSingleton.Instance.startCheck = false;
		Application.LoadLevel(2);
	}

    public void StartGame() {
        var buttons = GetComponents<OneButton>() as OneButton[];

        foreach ( var obj in buttons ) {
            if ( obj.ButtonName.Equals( "Exit" ) || obj.ButtonName.Equals( "Start" ) ) {
                obj.enabled = true;
            }
        }

        mapM = GameObject.Find("Standard_Cube").GetComponent<MapManager>();
        sphere = GameObject.Find("BombBall").GetComponent<Sphere>();

        Debug.Log(sphere);
    }

    public void OnStartButton ( ) {
        var buttons = GetComponents<OneButton>() as OneButton[];

        foreach ( var obj in buttons ) {
            obj.enabled = true;

            if ( obj.ButtonName.Equals( "Exit" ) || obj.ButtonName.Equals( "Start" ) ) {
                obj.enabled = false;
            }
        }

        var text = GameObject.Find( "Timer" ).guiText;
        text.enabled = true;

        TimeMgr.Instance.Resume();

        CubeSingleton.Instance.startCheck = true;

        mapM.StageChange();

        CubeSingleton.Instance.startCheck = false;
        mapM.standardCube.transform.rotation = new Quaternion(0, 0, 0, 1);
    }

    public void OnExitButton ( ) {
        Application.Quit();
    }

    public void OnLeftButton ( ) {
		if (sphere != null && sphere.sphereCamera.camera.enabled == false && sphere.spinCheck == false && sphere.moveCheckTime == 0.0f) {
			sphere.spinCheck = true;
			sphere.spinType = 3;
		}
    }

    public void OnRightButton ( ) {
		if (sphere != null && sphere.sphereCamera.camera.enabled == false && sphere.spinCheck == false && sphere.moveCheckTime == 0.0f) {
			sphere.spinCheck = true;
			sphere.spinType = 1;
		}
    }

    public void OnUpButton ( ) {
		if (sphere != null && sphere.sphereCamera.camera.enabled == false && sphere.spinCheck == false && sphere.moveCheckTime == 0.0f) {
			sphere.spinCheck = true;
			sphere.spinType = 0;
		}
    }

    public void OnDownButton ( ) {
		if (sphere != null && sphere.sphereCamera.camera.enabled == false && sphere.spinCheck == false && sphere.moveCheckTime == 0.0f) {
			sphere.spinCheck = true;
			sphere.spinType = 2;
		}
    }

    public void OnPushButton()
    {
		if (sphere != null && sphere.sphereCamera.camera.enabled == false && sphere.spinCheck == false && sphere.moveCheckTime == 0.0f) {
			sphere.rigidbody.isKinematic = false;
			sphere.spinType = 4;
			sphere.rigidbody.useGravity = true;
			sphere.SphereCameraChange ();
			sphere.pushCheck = true;
		}
    }
}
