using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserSwitchFan : MonoBehaviour {

    public Transform theSwitch, fan;
    private int onOff; //0 is off, 1 is on

    // Use this for initialization
    void Start () {
        onOff = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown(){
        onOff = 1 - onOff;

        //Debug.Log(onOff);

        FanRun.receiveSwitch(onOff);

    }
}
