using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour
{
	private float sceneCheckTime = 0.0f;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		sceneCheckTime += Time.deltaTime;

		if (sceneCheckTime >= 5.0f) {
			Application.LoadLevel (0);
		}
	}
}