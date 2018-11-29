using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_AlcoholBurnerControl : MonoBehaviour {

    public GameObject fireEffect;
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
        ETR_IceCube.ChangeHeatState();
        if (fireEffect.activeSelf)
        {
            fireEffect.SetActive(false);
        }
        else {
            fireEffect.SetActive(true);
        }
        burnerControl.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
    }
}
