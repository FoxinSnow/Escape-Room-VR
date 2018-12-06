using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ExitDoor : MonoBehaviour {

    public Transform door;
    public GameObject lightSource, headsetCollision, cameraFader;
    public UnityEngine.Events.UnityEvent doorEvent;
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
        
        if (isOpen) {
            if (door.transform.localRotation.z > -120f)
            {
                door.transform.Rotate(0, 0, -15.0f * Time.deltaTime);
            }
            else {

                isOpen = false;
            }

            Debug.Log(door.transform.localRotation.z);
        }
        
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        doorEvent.Invoke();
        headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().blinkTransitionSpeed = 3.0f;
        headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().fadeColor = Color.white;
        isOpen = true;
        lightSource.SetActive(true);
        cameraFader.SetActive(true);
        doorKnobInteraction.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
    }

}
