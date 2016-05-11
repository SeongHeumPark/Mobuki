using UnityEngine;
using System.Collections;

public class MoveFoward : MonoBehaviour {

    public float distance = 1f;
    private Vector3 dir;
    private Vector3 pos;
	// Use this for initialization
	void Start () {
        dir = transform.parent.forward;
        pos = transform.position;
        pos += dir * distance;
        transform.position = pos;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
