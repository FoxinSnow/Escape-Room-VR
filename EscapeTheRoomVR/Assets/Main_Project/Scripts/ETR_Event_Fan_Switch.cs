using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

// Algorithm designed and coded by Fei Huang
// Modified for VR by Yuqi Wang
public class ETR_Event_Fan_Switch : MonoBehaviour {

    public HoverButton hoverButton;
    public GameObject fan;
    public bool isOn;
    public float currentSpeed, maxSpeed, accelerateSpeed;

    private void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void Update()
    {
        if (isOn)
        {
            // When the fan is on
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += accelerateSpeed * Time.deltaTime;
            }
            else
            {
                currentSpeed = maxSpeed;
            }
        }
        else {

            // When the fan is off
            if (currentSpeed > 0)
            {
                currentSpeed -= accelerateSpeed/2 * Time.deltaTime;
            }
            else
            {
                currentSpeed = 0;
            }

        }

        fan.gameObject.transform.Rotate(0, currentSpeed, 0);
    }

    private void OnButtonDown(Hand hand)
    {
        SwitchFan();
    }

    private void SwitchFan()
    {
        if (isOn)
        {
            isOn = false;
        }
        else {
            isOn = true;
        }
    }
}
