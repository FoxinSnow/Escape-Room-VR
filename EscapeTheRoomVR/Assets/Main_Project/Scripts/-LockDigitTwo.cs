using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Fei Huang
public class LockDigitTwo : MonoBehaviour {

    public Transform lock2;
    private float lock2Angle, v, senstive;

    // Use this for initialization
    void Start () {
        lock2Angle = 0;
        senstive = 0.3f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag(){
        v += Input.GetAxis("Mouse Y");
        lock2.Rotate(v * senstive, 0f, 0f);
        lock2Angle += v;
        //Debug.Log(lock1Angle);

        //range from 0 to 360f
        if (lock2Angle > 360f)
        {
            lock2Angle = lock2Angle % 360f;
        }

        //not allow negative number
        if (lock2Angle < 0)
        {
            lock2Angle = 360f - lock2Angle;
        }

        //get a range of 10f for fault-tolerance
        if (lock2Angle > 145f && lock2Angle < 155f)
        {
            Debug.Log("open second digit!");
        }
    }
}
