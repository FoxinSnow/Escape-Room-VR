using System.Collections;
using System.Collections.Generic;
using VRTK.Controllables.ArtificialBased;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_Tutorial_Tap : MonoBehaviour {

    public GameObject tutorialControl;
    public UnityEngine.Events.UnityEvent tapEvent;
    private VRTK_ArtificialRotator tapRotator;
    private bool triggered;

    // Use this for initialization
    void Start () {
        triggered = false;
        tapRotator = this.GetComponent<VRTK_ArtificialRotator>();
    }

    private void Update()
    {
        if (tutorialControl == null || tutorialControl.activeSelf)
        {
            if (tapRotator.GetValue() > 15.0f && !triggered)
            {
                tapEvent.Invoke();
                triggered = true;
            }
        }
        else {
            if (tapRotator.GetValue() > 15.0f && !triggered)
            {
                
            }
        }
    }

}
