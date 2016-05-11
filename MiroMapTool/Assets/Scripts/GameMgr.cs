using UnityEngine;
using System.Collections;
using System.IO;

public class GameMgr : MonoBehaviour {

    // Use this for initialization
    void Awake ( ) {
        ObstaclesMgr.Instance.MakeObstacles();
    }

    void Update ( ) {
    }
}
