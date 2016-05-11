using UnityEngine;
using System.Collections;

public class TransParent : MonoBehaviour {

    private Color oldColor;
    private Color newColor;

    public float alpha = 0.6f;
    // Use this for initialization
    void Start ( ) {
    }

    // Update is called once per frame
    void Update ( ) {
        oldColor = this.gameObject.renderer.material.color;
        newColor = oldColor;
        newColor.a = alpha;
        this.gameObject.renderer.material.color = newColor;
    }
}
