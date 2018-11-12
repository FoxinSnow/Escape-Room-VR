using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_FridgeLockRotation : MonoBehaviour {

    private int currentRotation;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        currentRotation = (int)this.gameObject.transform.localEulerAngles.z;
        switch (currentRotation) {
            case -60:
                this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 300);
                break;

            case -120:
                this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 240);
                break;

            case -180:
                this.gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
                break;

        }
    }
}
