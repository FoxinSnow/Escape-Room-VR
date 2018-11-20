using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Fei Huang
public class LockDigitOne : MonoBehaviour {

    public Transform lock1;
    private float lock1Angle, v, senstive;

    // Use this for initialization
    void Start () {
        lock1Angle = 0;
        senstive = 0.3f;
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnMouseDrag()
    {
        v += Input.GetAxis("Mouse Y");
        lock1.Rotate(v * senstive, 0f, 0f);
        lock1Angle += v;
        //Debug.Log(lock1Angle);

        //range from 0 to 360f
        if (lock1Angle > 360f)
        {
            lock1Angle = lock1Angle % 360f;
        }

        //not allow negative number
        if (lock1Angle < 0)
        {
            lock1Angle = 360f - lock1Angle;
        }

        //get a range of 10f for fault-tolerance
        if (lock1Angle > 145f && lock1Angle < 155f)
        {
            Debug.Log("open first digit!");
        }
    }
}
