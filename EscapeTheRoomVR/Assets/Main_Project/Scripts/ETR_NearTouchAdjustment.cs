using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.GrabAttachMechanics;
using UnityEngine;

public class ETR_NearTouchAdjustment : MonoBehaviour {

    public GameObject controllerObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "NearTouchArea") {
            Debug.Log("Near Touch Enabled!");
            controllerObject.GetComponent<VRTK_InteractNearTouch>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "NearTouchArea")
        {
            Debug.Log("Near Touch Disabled!");
            controllerObject.GetComponent<VRTK_InteractNearTouch>().enabled = false;
        }
    }
}
