using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class ETR_PressableFeedback : MonoBehaviour {

    public AudioSource soundEffect;

    public void OnButtonDown(Hand fromHand)
    {
        /*
        fromHand.TriggerHapticPulse(1000);
        if (soundEffect != null) {
            soundEffect.Play();
        }
        */
    }

    public void OnButtonUp(Hand fromHand)
    {

    }
 
}
