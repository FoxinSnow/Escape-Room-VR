using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ClockHand : MonoBehaviour {

    public UnityEngine.Events.UnityEvent iceCubeEvent;
    private VRTK_InteractableObject clockHandInteraction;
    private VRTK_ArtificialRotator clockHandRotator;
    private bool isGrabbed;

    private float previousAngle;
    private float newAngle;

	// Use this for initialization
	void Start () {
        isGrabbed = false;
        clockHandRotator = this.GetComponent<VRTK_ArtificialRotator>();
        previousAngle = 0;
        newAngle = 0;
    }

    // Update is called once per frame
    protected virtual void Update() {
        Debug.Log(clockHandRotator.GetValue());
        if (isGrabbed) {
            newAngle = clockHandRotator.GetValue();
            Debug.Log("Previous Angle: " + previousAngle);
            Debug.Log("New Angle:" + newAngle);
            if (newAngle != previousAngle)
            {
                float delta = newAngle - previousAngle;
                ETR_ClockControl.TurnClock(true, delta * 0.05f);
                previousAngle = newAngle;
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
        //clockGrabEvent.Invoke();
    }


    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
        previousAngle = clockHandRotator.GetValue();
        //clockHandRotator.angleLimits.minimum = previousAngle;
        //clockUngrabEvent.Invoke();
    }
}
