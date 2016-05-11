using UnityEngine;
using System.Collections;

public class OneButton : MonoBehaviour {
    public Rect button = new Rect( 0, 0, 100, 50 );
    public string buttonName;
    public GUISkin buttonSkin;
    public float alpha = 1f;
    public float speed = 1f;

    public string ButtonName {
        get { return buttonName; }
    }

    void Start ( ) {
    }

    void Update ( ) {
        if ( alpha <= 1 ) {
            alpha += speed * Time.deltaTime;
        }
    }

    void OnGUI ( ) {
        GUI.skin = buttonSkin;
        GUI.backgroundColor = new Color( 1f, 1f, 1f, alpha );
        GUI.contentColor = new Color( 1f, 1f, 1f, alpha );
        if ( GUI.Button( button, buttonName ) ) {

            if ( buttonName.Equals( "Start" ) ) {
                GameStateMgr.Instance.OnStartButton();
            }
            else if ( buttonName.Equals( "Exit" ) ) {
                GameStateMgr.Instance.OnExitButton();
            }
            else if ( buttonName.Equals( "Left" ) ) {
                GameStateMgr.Instance.OnLeftButton();
            }
            else if ( buttonName.Equals( "Right" ) ) {
                GameStateMgr.Instance.OnRightButton();
            }
            else if ( buttonName.Equals( "Up" ) ) {
                GameStateMgr.Instance.OnUpButton();
            }
            else if ( buttonName.Equals( "Down" ) ) {
                GameStateMgr.Instance.OnDownButton();
            }
            else if (buttonName.Equals("Push"))
            {
                GameStateMgr.Instance.OnPushButton();
            }
        }
    }
}
