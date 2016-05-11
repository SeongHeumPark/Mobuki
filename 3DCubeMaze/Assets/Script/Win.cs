using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	public float sceneCheckTime = 0.0f;

	// Use this for initialization
	void Start () {
		ParticleMgr.Instance.Firework ();
		ParticleMgr.Instance.Firework ();
		ParticleMgr.Instance.Firework ();
	}
	
	// Update is called once per frame
	void Update () {
		sceneCheckTime += Time.deltaTime;

		if (sceneCheckTime >= 5.0f) {
			Application.LoadLevel (0);
		}
	}
}
