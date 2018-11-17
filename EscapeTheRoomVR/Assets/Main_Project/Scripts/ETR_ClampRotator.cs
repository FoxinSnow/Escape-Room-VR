using System;
using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ClampRotator : MonoBehaviour {

    public Transform clamp;
    private VRTK_ArtificialRotator clampRotator;
    private VRTK_InteractableObject clampInteraction;
    private bool isGrabbed;

    private void Start()
    {
        isGrabbed = false;
        clampRotator = this.GetComponent<VRTK_ArtificialRotator>();
    }

    protected virtual void Update()
    {
        if (isGrabbed)
        {
            clamp.localPosition = new Vector3(-0.2345288f + (clampRotator.GetValue() / 1080f) * -0.15f, clamp.localPosition.y, clamp.localPosition.z);
        }
    }

    protected virtual void OnEnable()
    {
        clampInteraction = this.GetComponent<VRTK_InteractableObject>();
        clampInteraction.InteractableObjectGrabbed += InteractableObjectGrabbed;
        clampInteraction.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
    }

    protected virtual void OnDisable()
    {
        clampInteraction.InteractableObjectGrabbed -= InteractableObjectGrabbed;
        clampInteraction.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
    }

    protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
    }


    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
    }


}
