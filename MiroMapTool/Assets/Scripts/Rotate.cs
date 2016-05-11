using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

    float speed = 500f;

    private float x = 0f;
    private float y = 0f;

    float xSpeed = 500;
    float ySpeed = 500;

    // Use this for initialization
    void Start ( ) {
        Vector3 angle = transform.eulerAngles;
        x = angle.y;
        y = angle.x;
    }

    // Update is called once per frame
    void Update ( ) {
        if ( Input.GetMouseButton( 0 ) ) {

            x -= Input.GetAxis( "Mouse X" ) * xSpeed * 0.02f;
            y += Input.GetAxis( "Mouse Y" ) * ySpeed * 0.02f;

            var rotation = Quaternion.Euler( y, x, 0 );
            transform.rotation = Quaternion.Lerp( transform.rotation, rotation, speed * Time.deltaTime );
        }
    }
}
