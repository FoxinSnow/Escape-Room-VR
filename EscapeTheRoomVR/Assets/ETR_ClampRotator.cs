using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ClampRotator : MonoBehaviour {

    public Transform clamp;
    private VRTK_ArtificialRotator clampInteraction;

    private void Start()
    {
        clampInteraction = this.GetComponent<VRTK_ArtificialRotator>();
    }

    protected virtual void OnEnable()
    {
    }

    protected virtual void OnDisable()
    {
    }

    protected virtual void Update()
    {
        clamp.localPosition = new Vector3(-0.2345288f + (clampInteraction.GetValue() / -1080f) * -0.15f, clamp.localPosition.y, clamp.localPosition.z);
    }

    protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {

        Debug.Log("Grabbed");
    }

    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("UNGrabbed");
    }

}
