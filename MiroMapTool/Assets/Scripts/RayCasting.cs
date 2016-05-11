using UnityEngine;
using System.Collections;

public class RayCasting : MonoBehaviour {

    private static Destroy selected;
    private static Destroy prev;
    public Camera c;
	// Use this for initialization
	void Start () {
        
        //c = this.camera;
	}
	
	// Update is called once per frame
	void Update () {
        if ( Input.GetMouseButtonUp(0) ) {
            Ray camRay = c.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay( camRay.origin, camRay.direction * 10, Color.green );
            RaycastHit hit;

            if ( Physics.Raycast( camRay, out hit ) ) {
                if ( hit.collider.CompareTag( "Preview" ) ) {

                    if ( !selected ) {
                        selected = hit.collider.gameObject.GetComponent<Destroy>() as Destroy;
                        selected.renderer.material.color = Color.yellow;
                    }
                    else {
                        prev = selected;
                        selected = hit.collider.gameObject.GetComponent<Destroy>() as Destroy;
                        prev.renderer.material.color = selected.renderer.material.color;
                        selected.renderer.material.color = Color.yellow;
                    }
                }
            }
        }

        if ( Input.GetKeyUp(KeyCode.Delete) ) {
            if ( selected ) {
                GameObject obj = selected.gameObject;
                DestroyObject( obj );
            }
        }
	}
}
