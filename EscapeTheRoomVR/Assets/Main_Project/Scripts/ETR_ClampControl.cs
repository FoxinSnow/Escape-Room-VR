using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_ClampControl : MonoBehaviour {

    private bool isRotate;

    private Vector3 currentPosition;
    private Vector3 targetPosition;
    private float speed;
	// Use this for initialization
	void Start () {
        isRotate = false;
        speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (isRotate) {
            this.gameObject.transform.localPosition = Vector3.Lerp(currentPosition, targetPosition, speed);
        }
	}

    public void setMovement() {
        currentPosition = this.gameObject.transform.localPosition;
        //targetPosition = ;
        isRotate = true;
    }

}
