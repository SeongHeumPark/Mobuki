using UnityEngine;
using System.Collections;
using Leap;

public class RightHandBehaviour : SkeletalHand {
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

		if (timer > 0.5f) {
			if (frame.Hands.Frontmost.IsRight) {
				if (frame.Hands.Rightmost.PalmVelocity.x > 300) {
					Debug.Log ("PalmVelocity.x : " + frame.Hands.Frontmost.PalmVelocity.x);
					GameStateMgr.Instance.OnRightButton ();
				} else if (frame.Hands.Leftmost.PalmVelocity.x < -300) {
					Debug.Log ("PalmVelocity.x : " + frame.Hands.Frontmost.PalmVelocity.x);
					GameStateMgr.Instance.OnLeftButton ();
				} else if (frame.Hands.Frontmost.PalmVelocity.y > 300) {
					Debug.Log ("PalmVelocity.y : " + frame.Fingers.Frontmost.TipVelocity.y);
					GameStateMgr.Instance.OnUpButton ();
				} else if (frame.Hands.Frontmost.PalmVelocity.y < -300) {
					Debug.Log ("PalmVelocity.y : " + frame.Fingers.Frontmost.TipVelocity.y);
					GameStateMgr.Instance.OnDownButton ();
				}

				timer = 0.0f;
			}
		}
	}
}