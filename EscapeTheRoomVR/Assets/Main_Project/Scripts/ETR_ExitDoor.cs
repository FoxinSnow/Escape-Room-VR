using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_ExitDoor : MonoBehaviour {

    public Transform door;
    public AudioSource doorSoundEffect;
    private VRTK_InteractableObject doorKnobInteraction;

    private bool isOpen;
    // Use this for initialization
    void Start () {
        isOpen = false;
    }

    protected virtual void OnEnable()
    {
        doorKnobInteraction = GetComponent<VRTK_InteractableObject>();
        doorKnobInteraction.InteractableObjectUsed += InteractableObjectUsed;
        doorKnobInteraction.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        doorKnobInteraction.InteractableObjectUsed -= InteractableObjectUsed;
        doorKnobInteraction.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void Update()
    {

    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        isOpen = true;
        if (doorSoundEffect != null)
        {
            doorSoundEffect.Play();
        }
        doorKnobInteraction.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
    }

}
