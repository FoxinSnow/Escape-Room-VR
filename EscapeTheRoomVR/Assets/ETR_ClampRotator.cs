using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_ClampRotator : MonoBehaviour {


    private VRTK_InteractableObject interactableObject;


    protected virtual void OnEnable()
    {
        interactableObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
        interactableObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
    }

    protected virtual void OnDisable()
    {
        interactableObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
        interactableObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
    }

    protected virtual void Update()
    {

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
