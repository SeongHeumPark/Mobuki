using UnityEngine;
using System.Collections;
using Leap;

public class LeftHandBehaviour : SkeletalHand {
	private Controller controller;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		Frame frame = controller.Frame ();

		if (timer >= 0.5f) {
			if (frame.Hands.Frontmost.IsLeft) {
				if (frame.Hands.Frontmost.PalmVelocity.y < -300) {
					Debug.Log ("PalmVelocity.y : " + frame.Hands.Frontmost.PalmVelocity.y);
					GameStateMgr.Instance.OnPushButton ();
				}
			}
		}
	}
}