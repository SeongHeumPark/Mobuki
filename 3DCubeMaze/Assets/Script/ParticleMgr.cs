using UnityEngine;
using System.Collections;

public class ParticleMgr : MonoBehaviour {

    static private ParticleMgr instance;

    static public ParticleMgr Instance {
        get {
            if ( instance == null ) {
                instance = FindObjectOfType( typeof( ParticleMgr ) ) as ParticleMgr;

                if ( instance == null ) {

                    instance = new GameObject( "TimeMgr", typeof( ParticleMgr ) ).GetComponent<ParticleMgr>();
                }
            }

            return instance;
        }
    }
    
    public GameObject firework;

    public void Firework() {
        GameObject obj = Instantiate( firework, Vector3.zero, Quaternion.identity) as GameObject;
        Destroy(obj, 5f);
    }
}