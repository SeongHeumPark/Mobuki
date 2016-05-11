using UnityEngine;
using System.Collections;

public class SetParent : MonoBehaviour {

    public Transform parent;
    public string parentName = "Miro";

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if ( parent == null ) {
            parent = GameObject.Find( parentName ).transform;

            transform.parent = parent;           
        }
        

	}
}
