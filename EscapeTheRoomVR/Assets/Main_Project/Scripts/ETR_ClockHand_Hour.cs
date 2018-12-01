using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ClockHand_Hour : MonoBehaviour
{

    private VRTK_InteractableObject clockHandInteraction;
    private VRTK_ArtificialRotator clockHandRotator;
    private bool isGrabbed;
    private float previousAngle;
    private float newAngle;

    // Use this for initialization
    void Start()
    {
        isGrabbed = false;
        clockHandRotator = this.GetComponent<VRTK_ArtificialRotator>();
        previousAngle = 0;
        newAngle = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //Debug.Log(clockHandRotator.GetValue());
        if (isGrabbed)
        {
            newAngle = clockHandRotator.GetValue();
            if (!newAngle.Equals(previousAngle))
            {
                if (newAngle - previousAngle < 0)
                {
                    Debug.Log("BLOCKED!");
                    clockHandRotator.SetValue(previousAngle);
                }
                else {
                    float delta = newAngle - previousAngle;
                    ETR_ClockControl.TurnClockHour(true, delta * 0.15f);
                    ETR_AlarmControl.TurnClockHour(true, delta * 0.15f);
                    previousAngle = newAngle;
                }
                
            }
        }
    }

    protected virtual void OnEnable()
    {
        clockHandInteraction = this.GetComponent<VRTK_InteractableObject>();
        clockHandInteraction.InteractableObjectGrabbed += InteractableObjectGrabbed;
        clockHandInteraction.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
    }

    protected virtual void OnDisable()
    {
        clockHandInteraction.InteractableObjectGrabbed -= InteractableObjectGrabbed;
        clockHandInteraction.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
    }

    protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
    }


    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
        previousAngle = clockHandRotator.GetValue();
        //clockHandRotator.restingAngle = previousAngle;
        //clockHandRotator.angleLimits.minimum = previousAngle;
    }
}

