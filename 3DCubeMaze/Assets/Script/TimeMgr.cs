using UnityEngine;
using System.Collections;

public class TimeMgr : MonoBehaviour {
    static private TimeMgr instance;

    static public TimeMgr Instance {
        get {
            if ( instance == null ) {
                instance = FindObjectOfType( typeof( TimeMgr ) ) as TimeMgr;

                if ( instance == null ) {

                    instance = new GameObject( "TimeMgr", typeof( TimeMgr ) ).GetComponent<TimeMgr>();
                }
            }

            return instance;
        }
    }

    public float limitTime = 60;
    private float reserveTime;
    private bool isPaused;

	// Use this for initialization
	void Start () {
        isPaused = true;
        reserveTime = limitTime;
	}
	
	// Update is called once per frame
	void Update () {
        if ( isPaused ) {
            return;
        }

        if ( limitTime > 0 ) {
            limitTime -= Time.deltaTime;
        }
        else {
            limitTime = 0;
        }
	}

    public string decriptionTime ( ) {
        string sTime = string.Format(" {0} : {1} ", ((int)limitTime/60), (limitTime%60).ToString("0.##") );
        return sTime;
    }

    public void ResetTime ( ) {
        limitTime = reserveTime;
    }

    public void Pause ( ) {
        isPaused = true;
    }

    public void Resume ( ) {
        isPaused = false;
    }

}
