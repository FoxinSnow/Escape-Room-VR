using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDigitThree : MonoBehaviour {


    public Transform lock3;
    private float lock3Angle, v, senstive;

    // Use this for initialization
    void Start () {
        lock3Angle = 0;
        senstive = 0.3f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDrag()
    {
        v += Input.GetAxis("Mouse Y");
        lock3.Rotate(v * senstive, 0f, 0f);
        lock3Angle += v;
        //Debug.Log(lock1Angle);

        //range from 0 to 360f
        if (lock3Angle > 360f)
        {
            lock3Angle = lock3Angle % 360f;
        }

        //not allow negative number
        if (lock3Angle < 0)
        {
            lock3Angle = 360f - lock3Angle;
        }

        //get a range of 10f for fault-tolerance
        if (lock3Angle > 145f && lock3Angle < 155f)
        {
            Debug.Log("open third digit!");
        }
    }
}
