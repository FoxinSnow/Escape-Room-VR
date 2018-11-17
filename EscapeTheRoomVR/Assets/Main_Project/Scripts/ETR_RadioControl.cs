using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_RadioControl : MonoBehaviour {

    public Transform popButton, backwardButton, playButton, forwardButton, stopButton;
    public AudioSource audioSource;

    private bool isOn;

    // Use this for initialization
    void Start () {
        isOn = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Radio_PlayPause() {
        if (isOn) {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
                playButton.localPosition = new Vector3(0.03267755f, playButton.localPosition.y, playButton.localPosition.z);
            }
            else
            {
                audioSource.Play();
                playButton.localPosition = new Vector3(0.028f, playButton.localPosition.y, playButton.localPosition.z);
            }
        }
    }

    public void Radio_Stop()
    {
        if (isOn) {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                playButton.localPosition = new Vector3(0.03267755f, playButton.localPosition.y, playButton.localPosition.z);
            }
        }
       
    }

    public void Radio_Forward()
    {
        if (audioSource.pitch == 2.0f)
        {
            audioSource.pitch = 1.0f;
            forwardButton.localPosition = new Vector3(0.03267755f, forwardButton.localPosition.y, forwardButton.localPosition.z);   
        }
        else {
            audioSource.pitch = 2.0f;
            forwardButton.localPosition = new Vector3(0.028f, forwardButton.localPosition.y, forwardButton.localPosition.z);
            backwardButton.localPosition = new Vector3(0.03267755f, backwardButton.localPosition.y, backwardButton.localPosition.z);
        }
        
    }

    public void Radio_Backward()
    {
        if (audioSource.pitch == -1.0f)
        {
            audioSource.pitch = 1.0f;
            backwardButton.localPosition = new Vector3(0.03267755f, backwardButton.localPosition.y, backwardButton.localPosition.z);
            
        }else
        {
            audioSource.pitch = -1.0f;
            backwardButton.localPosition = new Vector3(0.028f, backwardButton.localPosition.y, backwardButton.localPosition.z);
            forwardButton.localPosition = new Vector3(0.03267755f, forwardButton.localPosition.y, forwardButton.localPosition.z);
        }
    }

    public void Radio_OnOff() {
        if (isOn)
        {
            isOn = false;
        }
        else {
            isOn = true;
        }
    }

    public void Radio_ResetButtons() {
        // 0.03267755
    }

}
