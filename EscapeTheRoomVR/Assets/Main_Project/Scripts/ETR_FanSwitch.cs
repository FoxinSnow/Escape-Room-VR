using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Fei Huang(Algorithm), Yuqi Wang(VR Interaction)
public class ETR_FanSwitch : MonoBehaviour {

    public Transform fanTransform;
    public bool isOn;
    public float currentSpeed, maxSpeed, accelerateSpeed;
    private VRTK_InteractableObject interactableObject;
    public UnityEngine.Events.UnityEvent switchEvent;

    public void Start()
    {
    }

    protected virtual void OnEnable()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectUsed += InteractableObjectUsed;
        interactableObject.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        interactableObject.InteractableObjectUsed -= InteractableObjectUsed;
        interactableObject.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void Update()
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
        else
        {

            // When the fan is off
            if (currentSpeed > 0)
            {
                currentSpeed -= accelerateSpeed / 2 * Time.deltaTime;
            }
            else
            {
                currentSpeed = 0;
            }

        }

        fanTransform.Rotate(0, currentSpeed, 0);
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        switchEvent.Invoke();
        SwitchFan();
        float degree = this.gameObject.transform.localEulerAngles.y;
        this.gameObject.transform.localEulerAngles = new Vector3(0, -degree, 0);
        interactableObject.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {}

    private void SwitchFan()
    {
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
    }

}
