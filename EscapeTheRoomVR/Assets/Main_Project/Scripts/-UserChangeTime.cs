using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserChangeTime : MonoBehaviour {

    public Transform hour, minute;
    private float angle, v, senstive;

    // Use this for initialization
    void Start () {
        angle = 0;
        senstive = 0.8f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag()
    {
        v = 0;
        v += Input.GetAxis("Mouse Y");
        //hour.localRotation = Quaternion.Euler(0f, 0f, v * senstive);
        //minute.localRotation = Quaternion.Euler(0f, 0f, 12 * v * senstive);
        angle = v * senstive;

        angle = angle % 360f; //control the angle between -360 to 360

        ClockRun.TurnClock(true, angle);
    }
}
