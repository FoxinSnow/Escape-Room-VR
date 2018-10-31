using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRun : MonoBehaviour {

    public Transform fan;
    private static float y, n, ySpeed; //n used to store the final speed
    private static int onOff;

    // Use this for initialization
    void Start () {
        y = 0f;
        n = 20f;
        ySpeed = 1.0f;
        onOff = 0;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(onOff);

        if (onOff == 1)
        {
            if (y < n)
            {
                y += ySpeed * Time.deltaTime;
            }
            else
            {
                y = n;
                //Debug.Log(n);
            }
        }

        if (onOff == 0 && y > 0)
        {
            y -= ySpeed * Time.deltaTime;

            //let the final speed = 0
            if (y < 0)
            {
                y = 0;
            }
        }

        fan.Rotate(0, y, 0);
    }

    //static method to receive on and off
    public static void receiveSwitch(int oo)
    {
        //only fan in the final stage, the input switch control can have effect
        if (y.Equals(0) || y.Equals(n))
        {
            onOff = oo;
        }
    }
}
