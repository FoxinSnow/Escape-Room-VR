using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

public class ETR_ClockHand : MonoBehaviour {

    //public UnityEngine.Events.UnityEvent clockGrabEvent;
    //public UnityEngine.Events.UnityEvent clockUngrabEvent;

    private VRTK_InteractableObject clockHandInteraction;
    private VRTK_ArtificialRotator clockHandRotator;
    private bool isGrabbed;

	// Use this for initialization
	void Start () {
        isGrabbed = false;
        clockHandRotator = this.GetComponent<VRTK_ArtificialRotator>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        if (isGrabbed) {
            ETR_ClockControl.TurnClock(true, clockHandRotator.GetValue());
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
        //clockUngrabEvent.Invoke();
    }
}
