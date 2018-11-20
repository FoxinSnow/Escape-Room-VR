using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_AlcoholBurnerControl : MonoBehaviour {

    public GameObject fireEffect;
    public GameObject heatingArea;
    private VRTK_InteractableObject burnerControl;
    private bool isOn;

    // Use this for initialization
    void Start () {
        isOn = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    protected virtual void OnEnable()
    {
        burnerControl = this.GetComponent<VRTK_InteractableObject>();
        burnerControl.InteractableObjectUsed += InteractableObjectUsed;
        burnerControl.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        burnerControl.InteractableObjectUsed -= InteractableObjectUsed;
        burnerControl.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {

        if (isOn)
        {
            heatingArea.SetActive(false);
            isOn = false;
        }
        else {
            heatingArea.SetActive(true);
            isOn = true;
        }

        burnerControl.enabled = false;
    }


    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
    }
}
