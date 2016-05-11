using UnityEngine;
using System.Collections;

public struct Stage
{
    public int[] cube;
    public int cubeLevel;
    public int stageLevel;
    public int startCube;
    public int endCube;
    public bool teleportCheck;
}

public struct Cube
{
    public GameObject cube;
    public int type;
    public int teleDestination;
}

public enum CUBETYPE
{
    NORMAL = 0,
    START,
    END,
    TELEPORT
}

public class CubeSingleton
{
    private static CubeSingleton instance = null;

    public static CubeSingleton Instance
    {
        get
        {
            if (instance == null)
                instance = new CubeSingleton();

            return instance;
        }
    }

    public Stage[] cubeStage;
    private const int StageCount = 6;

    public Cube[] cube3by3;
    public Cube[] cube4by4;

    public int stageNum = 0;

    public GameObject standardCube;
    public GameObject prefabCube;
    public GameObject bomb;
    
    public int NowStage = 0;

    public bool startCheck = true;
    public Cube[] nowCube = null;
    public bool nextCheck = false;

    public bool teleportCheck = true;
    public bool cubeby3ClearCheck = true;

    public float cubebyTimer = 0f;

	public bool teleportx = false;
	public bool teleporty = false;
	public bool teleportX = false;
	public bool teleportY = false;

    public void CreateCubeInformation(GameObject prefab, GameObject stardard ,GameObject sphere)
    {
        // Stage 초기화
        cubeStage = new Stage[StageCount];
        StageCreate();

        // 큐브 초기화
        prefabCube = prefab; //Cube 정보
        standardCube = stardard;    // 기준 큐브의 정보
        bomb = sphere;
        cube3by3 = new Cube[27]; CubeCreate(cube3by3, 3);
        cube4by4 = new Cube[64]; CubeCreate(cube4by4, 4);
    }

    public void DestoryCubeInformation()
    {
    }

	public void ChangeTeleportCheck(bool state)
	{
		teleportCheck = state;
	}

    // 스테이지 생성
    private void StageCreate()
    {
        // 스테이지 1 / 하
        cubeStage[0].cube = new int[] { 0, 0, 0, 1, 0, 1, 0, 1, 0,
                                        0, 0, 0, 1, 0, 0, 1, 1, 1,
                                        1, 0, 1, 0, 0, 0, 0, 1, 0 };
        cubeStage[0].cubeLevel = 3;
        cubeStage[0].stageLevel = 1;
        cubeStage[0].startCube = 2;
        cubeStage[0].endCube = 16;
        cubeStage[0].teleportCheck = false;

        // 스테이지 2 / 중
        cubeStage[1].cube = new int[] { 1, 0, 0, 0, 0, 1, 0, 0, 0,
                                        0, 0, 0, 1, 0, 0, 1, 0, 1,
                                        0, 1, 1, 0, 1, 0, 0, 0, 0 };
        cubeStage[1].cubeLevel = 3;
        cubeStage[1].stageLevel = 2;
        cubeStage[1].startCube = 2;
        cubeStage[1].endCube = 22;
        cubeStage[1].teleportCheck = false;

        // 스테이지 3 / 중
        cubeStage[2].cube = new int[] { 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        cubeStage[2].cubeLevel = 4;
        cubeStage[2].stageLevel = 2;
        cubeStage[2].startCube = 3;
        cubeStage[2].endCube = 57;
        cubeStage[2].teleportCheck = false;

        // 스테이지 4 / 상
        cubeStage[3].cube = new int[] { 2, 0, 0, 1, 0, 0, 0, 0, 1,
                                        0, 0, 1, 0, 0, 0, 0, 0, 0,
                                        1, 1, 0, 0, 2, 1, 0, 0, 0 };
        cubeStage[3].cubeLevel = 3;
        cubeStage[3].stageLevel = 3;
        cubeStage[3].startCube = 2;
        cubeStage[3].endCube = 19;
        cubeStage[3].teleportCheck = true;

        // 스테이지 5 / 상
        cubeStage[4].cube = new int[] { 1, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1, 1, 0,
                                        1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0,
                                        1, 0, 1, 1, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1,
                                        0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1 };
        cubeStage[4].cubeLevel = 4;
        cubeStage[4].stageLevel = 3;
        cubeStage[4].startCube = 3;
        cubeStage[4].endCube = 39;
        cubeStage[4].teleportCheck = false;

        // 스테이지 6 / 최상
        cubeStage[5].cube = new int[] { 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1,
                                        1, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 1,
                                        1, 0, 1, 1, 1, 2, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0,
                                        2, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 0 };
        cubeStage[5].cubeLevel = 4;
        cubeStage[5].stageLevel = 4;
        cubeStage[5].startCube = 3;
        cubeStage[5].endCube = 48;
        cubeStage[5].teleportCheck = true;
    }

    private void CubeCreate(Cube[] cube, int type)
    {
        if (type == 3)
            CreateCubeType(cube, 3f, 3);

        else
            CreateCubeType(cube, 4.5f, 4);
    }

    private void CreateCubeType(Cube[] cubeObj, float offset, int maxCount)
    {
        Debug.Log(prefabCube);
        float z = -offset;
        int index = maxCount * maxCount;
        Debug.Log(maxCount);
        Debug.Log(index);
        Debug.Log(standardCube);
        for (int i = 0; i < maxCount; ++i)
        {
            float y = offset;
            for (int j = 0; j < maxCount; ++j)
            {
                float x = -offset;
                for (int k = 0; k < maxCount; ++k)
                {
                    Cube cube = new Cube();
                    cube.cube = GameObject.Instantiate(prefabCube) as GameObject;

                 //   Debug.Log(cube.cube);
                    cube.cube.transform.position = new Vector3(cube.cube.transform.position.x + x, cube.cube.transform.position.y + y, cube.cube.transform.position.z + z);
                    cube.cube.transform.parent = standardCube.transform;
                    cube.type = (int)CUBETYPE.NORMAL;
                    cube.teleDestination = -1;

                    if (maxCount == 3)
                        cube.cube.SetActive(false);

                    cubeObj[(i * index) + (j * maxCount) + k] = cube;

                    x += 3;
                }
                y -= 3;
            }
            z += 3;
        }
    }

    // 큐브 초기화
    public void CubeInit(bool type)
    {
        Cube[] cube = (type) ? cube3by3 : cube4by4;
        for (int i = 0; i < cube.Length; ++i)
        {
            cube[i].cube.SetActive(true);
            cube[i].cube.renderer.material.color = new Color(1, 1, 1, 0.5f);
            cube[i].type = (int)CUBETYPE.NORMAL;
            cube[i].teleDestination = -1;
            cube[i].cube.collider.isTrigger = false;
        }
    }

    public Cube[] GetCube(bool type)
    {
        return (type) ? cube3by3 : cube4by4;
    }

    public void GameClearCheck(GameObject obj)
    {
        // 3 by 3
        if (cubeStage[stageNum].cubeLevel == 3)
        {
            // 마지막 큐브를 통과한거냐??
            if (cube3by3[cubeStage[stageNum].endCube].cube == obj)
            {
                // 그럼 다음으로가장~~
                nextCheck = true; // 만약 nextCheck가 false면 죽었다는 것
                Debug.Log("다음차로 넘어갑시다");
                Sphere bomb2 = bomb.GetComponent<Sphere>();
                bomb2.MainCameraChange();
                bomb2.transform.position = new Vector3(100f, 100f, 100f);
            }
        }
        // 4 by 4
        else
        {
            // 마지막 큐브를 통과한거냐??
            if (cube4by4[cubeStage[stageNum].endCube].cube == obj)
            {
                // 그럼 다음으로가장~~
                nextCheck = true; // 만약 nextCheck가 false면 죽었다는 것
                Debug.Log("다음차로 넘어갑시다");
                Sphere bomb2 = bomb.GetComponent<Sphere>();
                bomb2.MainCameraChange();
                bomb2.transform.position = new Vector3(100f, 100f, 100f);
            }
        }
    }

    public void TeleportCheck( GameObject obj, GameObject sphere )
    {
        // 텔포 있냐
        if (cubeStage[stageNum].teleportCheck)
        {
            if (teleportCheck)
            {
                // 스테이지 보자~!!
                if (stageNum == 3)
                {
                    if (obj == cube3by3[0].cube)
                    {
						teleportx = true;
						teleporty = false;
                    }
                    else if (obj == cube3by3[22].cube)
                    {
						teleportx = false;
						teleporty = true;
                    }

					if (teleportx == true && teleporty == false)
					{
						sphere.transform.position = cube3by3[22].cube.transform.position;
						Debug.Log("0 to 22");
						teleportx = false;
						teleporty = false;
					}
					else if (teleportx == false && teleporty == true)
					{
						sphere.transform.position = cube3by3[0].cube.transform.position;
						Debug.Log("22 to 0");
						teleportx = false;
						teleporty = false;
					}
                }
                else if (stageNum == 5)
                {
                    if (obj == cube4by4[37].cube)
                    {
						teleportX = true;
						teleportY = false;
                    }
                    else if (obj == cube4by4[48].cube)
                    {
						teleportX = false;
						teleportY = true;
                    }

					if (teleportX == true && teleportY == false)
					{
						sphere.transform.position = cube4by4[48].cube.transform.position;
						Debug.Log("37 to 48");
						teleportX = false;
						teleportY = false;
					}
					else if (teleportX == false && teleportY == true)
					{
						sphere.transform.position = cube4by4[37].cube.transform.position;
						Debug.Log("48 to 37");
						teleportX = false;
						teleportY = false;
					}
                }

				ChangeTeleportCheck(false);
            }
        }
    }

    public bool GameStageCheck()
    {   
		++stageNum;
        standardCube.transform.rotation = new Quaternion(0, 0, 0, 1);
        bomb.transform.rotation = new Quaternion(0, 0, 0, 1);
        bomb.rigidbody.useGravity = false;
        teleportCheck = true;

        if (stageNum >= StageCount)
        {
            return false;
        }

        return true;
    }
}
