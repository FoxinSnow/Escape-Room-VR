using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ExitDoor : MonoBehaviour {

    public Transform door;
    public AudioSource doorSoundEffect;
    public GameObject lightSource;
    private VRTK_InteractableObject doorKnobInteraction;

    private bool isOpen;
    private Vector3 targetRotation;
    // Use this for initialization
    void Start () {
        isOpen = false;
        targetRotation = new Vector3(0, 0, -120.0f);
        lightSource.SetActive(false);
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

    void Update()
    {
        // Smooth animation
        /*
        if (isOpen) {
            door.localRotation = Quaternion.RotateTowards(door.localRotation, Quaternion.Euler(targetRotation), Time.deltaTime * 0.5f);
        }
        */
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        isOpen = true;
        if (doorSoundEffect != null)
        {
            doorSoundEffect.Play();
        }
        Debug.Log("Door unlocked");
        door.localEulerAngles = new Vector3(-90f,0,-120f);
        lightSource.SetActive(true);
        doorKnobInteraction.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
    }

}
