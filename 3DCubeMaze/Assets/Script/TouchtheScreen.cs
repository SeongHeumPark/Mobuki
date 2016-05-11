using UnityEngine;
using System.Collections;

public class TouchtheScreen : MonoBehaviour {

    public GUIText gText;
    public GameObject tText;
    public float timeInterval = 5;

    private float accumulateTime = 0;
    void Start ( ) {
        tText.guiText.enabled = false;
    }

    void Update ( ) {
        float a = gText.color.a;
        accumulateTime += Time.deltaTime;

        a = Mathf.Abs( Mathf.Sin( accumulateTime * timeInterval ) );
        Color input = gText.color;
        input.a = a;

        gText.color = input;

        //Android
        if ( Input.touchCount > 0 ) {
            
        }

        //PC
        if ( Input.GetMouseButtonUp(0) ) {
            Color c = new Color( 0, 0, 0, 0 );
            gText.color = c;
            this.enabled = false;
            GameStateMgr.Instance.StartGame();
            Destroy( this );
        }
    }
}
