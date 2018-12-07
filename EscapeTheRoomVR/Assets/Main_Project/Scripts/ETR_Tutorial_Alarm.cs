using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_Tutorial_Alarm : MonoBehaviour {

    public GameObject tutorialControl;
    public GameObject alarmObject;
    public GameObject highlightHalo;
    public UnityEngine.Events.UnityEvent alarmTutorialEvent;
    private VRTK_InteractableObject interactableObject;
    private bool triggered;

    private void Start()
    {
        if (tutorialControl.activeSelf)
        {
            alarmObject.GetComponent<VRTK_InteractableObject>().enabled = false;
            alarmObject.GetComponent<VRTK_InteractObjectHighlighter>().enabled = false;
            triggered = false;
        }
        else {
            triggered = true;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<VRTK_InteractableObject>().enabled = false;
            this.GetComponent<VRTK_InteractObjectHighlighter>().enabled = false;
        }
        

    }

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
    {
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        if (!triggered) {
            alarmObject.GetComponent<VRTK_InteractableObject>().enabled = true;
            alarmObject.GetComponent<VRTK_InteractObjectHighlighter>().enabled = true;
            interactableObject.enabled = false;
            highlightHalo.SetActive(false);
            alarmTutorialEvent.Invoke(); 
            triggered = true;
            this.GetComponent<BoxCollider>().enabled = false;
            this.GetComponent<VRTK_InteractableObject>().enabled = false;
            this.GetComponent<VRTK_InteractObjectHighlighter>().enabled = false;
        }
        
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    { }
}
