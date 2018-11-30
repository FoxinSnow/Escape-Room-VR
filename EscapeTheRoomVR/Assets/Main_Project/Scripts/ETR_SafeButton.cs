using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_SafeButton : MonoBehaviour {

    public UnityEngine.Events.UnityEvent buttonEvent;
    private VRTK_InteractableObject interactableObject;

    // Use this for initialization
    void Start() { }

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
    { }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        buttonEvent.Invoke();
        interactableObject.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    { }
}
