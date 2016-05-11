using UnityEngine;
using System.Collections;

public class StartPoint : MonoBehaviour {

    public GameObject startPoint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPoint.transform.position;
	}
}
