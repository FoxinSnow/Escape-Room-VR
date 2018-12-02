using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_RadioControl : MonoBehaviour {

    public Transform popButton, backwardButton, playButton, forwardButton, stopButton;
    public AudioSource audioSource;

    private bool isOn;
    private float currentPlayTime;
    private bool canUseTimer;

    // Use this for initialization
    void Start () {
        isOn = true;
        currentPlayTime = 0.0f;
        canUseTimer = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (canUseTimer) {
            currentPlayTime += Time.deltaTime * audioSource.pitch;
            if (currentPlayTime < 0)
            {
                currentPlayTime = 0;
            }

            if (currentPlayTime == 0 && audioSource.pitch == -1.0f)
            {
                Reset();
            }

            if (currentPlayTime > audioSource.clip.length - 2.5f && audioSource.pitch != -1.0f)
            {
                Reset();
            }

            //Debug.Log("Current Playing?" + audioSource.isPlaying);
            //Debug.Log("Current Play Time:" + currentPlayTime);
        }
    }

    public void Radio_PlayPause() {

            if (currentPlayTime == 0.0f && audioSource.pitch == -1.0f)
            {
                Reset();
            }
            else if (currentPlayTime > audioSource.clip.length - 2.5f && audioSource.pitch != -1.0f) {
                Reset();
            }
            else
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Pause();
                    playButton.localPosition = new Vector3(0.03267755f, playButton.localPosition.y, playButton.localPosition.z);
                    canUseTimer = false;
                }
                else
                {
                    audioSource.Play();
                    playButton.localPosition = new Vector3(0.028f, playButton.localPosition.y, playButton.localPosition.z);
                    canUseTimer = true;
                }
            }
    }

    public void Radio_Stop()
    {
        Reset();
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

    private void Reset()
    {
        audioSource.Pause();
        audioSource.pitch = 1.0f;
        forwardButton.localPosition = new Vector3(0.03267755f, forwardButton.localPosition.y, forwardButton.localPosition.z);
        playButton.localPosition = new Vector3(0.03267755f, playButton.localPosition.y, playButton.localPosition.z);
        backwardButton.localPosition = new Vector3(0.03267755f, backwardButton.localPosition.y, backwardButton.localPosition.z);
        canUseTimer = false;
    }

}
