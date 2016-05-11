using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    public GameObject companion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        companion.renderer.material.color = this.renderer.material.color;
	}

    void OnDestroy ( ) {
        Destroy( companion );
    }
}
