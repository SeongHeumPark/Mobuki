using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour
{
    public GameObject sphere;
    public GameObject prefabCube;
    public GameObject standardCube;

    public int stageCheck = 0;

	// Use this for initialization
    public void Start()
    {
        Debug.Log(prefabCube);
        CubeSingleton.Instance.CreateCubeInformation(prefabCube, standardCube, sphere);
		CubeSingleton.Instance.startCheck = true;
    }

    public void StageApply(bool type, int stageNum)
    {
        Cube[] cube = CubeSingleton.Instance.GetCube(type);
        // 시작, 끝 큐브 저장
        cube[CubeSingleton.Instance.cubeStage[stageNum].startCube].type = (int)CUBETYPE.START;
        cube[CubeSingleton.Instance.cubeStage[stageNum].endCube].type = (int)CUBETYPE.END;

        Debug.Log(CubeSingleton.Instance.cubeStage[stageNum].endCube);

        // 공을 시작 위치에 배치
        sphere.transform.position = cube[CubeSingleton.Instance.cubeStage[stageNum].startCube].cube.transform.position;
        sphere.rigidbody.useGravity = false;
		sphere.rigidbody.isKinematic = true;

        // 큐브 배치
        for (int i = 0; i < cube.Length; ++i)
        {
            int check = CubeSingleton.Instance.cubeStage[stageNum].cube[i];
            if (check > 0)
                cube[i].cube.SetActive(true);

            else
                cube[i].cube.SetActive(false);
        }
        // 마지막 큐브는 색깔을 변경        
        GameObject endCube = cube[CubeSingleton.Instance.cubeStage[stageNum].endCube].cube;
        endCube.renderer.material.color = new Color(1, 0.35f, 0.35f, 1);
        endCube.collider.isTrigger = true;

        Debug.Log(endCube.renderer.material.color);

        if (CubeSingleton.Instance.cubeStage[stageNum].teleportCheck)
        {
            if( stageNum == 3 )
            {
                cube[0].cube.renderer.material.color = new Color(0, 1, 0.2f, 1);
                cube[22].cube.renderer.material.color = new Color(0, 1, 0.2f, 1);

                cube[0].cube.collider.isTrigger = true;
                cube[22].cube.collider.isTrigger = true;
            }
            else if (stageNum == 5)
            {
                cube[37].cube.renderer.material.color = new Color(0, 1, 0.2f, 1);
                cube[48].cube.renderer.material.color = new Color(0, 1, 0.2f, 1);

                cube[37].cube.collider.isTrigger = true;
                cube[48].cube.collider.isTrigger = true;
            }
        }
    }

    public float timeChekc = 0;
    public void Update()
    {
        if (CubeSingleton.Instance.nextCheck)
        {
            CubeSingleton.Instance.cubebyTimer += Time.deltaTime;
            if (CubeSingleton.Instance.cubebyTimer > 3f)
            {
                CubeSingleton.Instance.cubebyTimer = 0f;
                CubeSingleton.Instance.cubeby3ClearCheck = true;
                if (CubeSingleton.Instance.GameStageCheck())
                {
                    CubeSingleton.Instance.nextCheck = false;
                    StageChange();
                }
				else {
					GameStateMgr.Instance.Win();
				}
            }
        }
        if (CubeSingleton.Instance.startCheck)
        {
            Vector3 check = new Vector3( 0, 0, 0 );
            check.y += 10f * Time.time;
            var rotation = Quaternion.Euler(check);
            transform.rotation = Quaternion.Lerp( transform.rotation, rotation, 10f * Time.deltaTime );
        }
    }

    public void StageChange()
    {
        // true
        // 3 by 3
        if (CubeSingleton.Instance.cubeStage[CubeSingleton.Instance.stageNum].cubeLevel == 3)
        {
            ActiveOut(false);
            CubeSingleton.Instance.CubeInit(true);
            StageApply(true, CubeSingleton.Instance.stageNum);
        }

        // false
        // 4 by 4
        else if (CubeSingleton.Instance.cubeStage[CubeSingleton.Instance.stageNum].cubeLevel == 4)
        {
            ActiveOut(true);
            CubeSingleton.Instance.CubeInit(false);
            StageApply(false, CubeSingleton.Instance.stageNum);
        }
    }

    public void ActiveOut(bool type)
    {
        Cube[] cube = CubeSingleton.Instance.GetCube(type);
        for (int i = 0; i < cube.Length; ++i)
            cube[i].cube.SetActive(false);
    }
}
