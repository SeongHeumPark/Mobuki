using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {
    public GUIText tTime;
    public Font font;
    public float timeDegree;

    private float changeTime;
    public float changeFontSizeTime;

    private float accumulateTime;
    private int count = 0;

    void Start ( ) {
        accumulateTime = 0;
        tTime.font = font;
        tTime.color = Color.green;

        tTime.text = TimeMgr.Instance.decriptionTime();
        changeTime = ( TimeMgr.Instance.limitTime * 3 ) / 4;
    }

    void Update ( ) {

        tTime.text = TimeMgr.Instance.decriptionTime();

        tTime.color = Color.Lerp( Color.green, Color.red, Time.time / changeTime );

        if ( TimeMgr.Instance.limitTime <= changeFontSizeTime ) {
            accumulateTime += timeDegree * Time.deltaTime;

            if ( accumulateTime >= 1f ) {
                accumulateTime = 0;
                count++;
            }

            if ( count % 2 == 0 ) {
                tTime.fontSize++;
            }
            else {
                tTime.fontSize--;
            }
        }
    }
}
