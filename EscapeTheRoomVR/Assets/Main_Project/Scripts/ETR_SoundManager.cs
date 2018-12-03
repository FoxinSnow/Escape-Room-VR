using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_SoundManager : MonoBehaviour {

    public AudioSource ambienceAudioSource;

    public AudioSource safeAudioSource;
    public AudioClip safeButton, safeButtonConfirm, safeUnlock;

    public AudioSource fanAudioSource;
    public AudioClip fanStart, fanRun;
    private bool isFanOn;

    public AudioSource radioButtonAudioSource;
    public AudioSource floorPieceAudioSource;
    public AudioSource switchAudioSource;
    public AudioSource burnerAudioSource;

	// Use this for initialization
	void Start () {
        isFanOn = false;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isFanOn && fanAudioSource.clip == fanStart && !fanAudioSource.isPlaying) {
            fanAudioSource.clip = fanRun;
            fanAudioSource.loop = true;
            fanAudioSource.Play();
        }
	}

    public void PlaySafeSoundEffect(int i) {
        switch (i) {
            case 0:
                safeAudioSource.clip = safeButton;      
                break;
            case 1:
                safeAudioSource.clip = safeButtonConfirm;
                break;
            case 2:
                safeAudioSource.clip = safeUnlock;
                break;
            default:
                safeAudioSource.clip = safeButton;
                break;
        }
        safeAudioSource.Play();
    }

    public void PlaySwitchSoundEffect() {
        switchAudioSource.Play();
    }

    public void PlayRadioButtonSoundEffect() {
        radioButtonAudioSource.Play();
    }

    public void PlayBurnerSoundEffect() {
        if (burnerAudioSource.isPlaying){
            burnerAudioSource.Stop();
        }
        else{
            burnerAudioSource.Play();
        } 
    }

    public void PlayFanSoundEffect() {
        if (isFanOn){
            isFanOn = false;
        }
        else {
            isFanOn = true;
        }

        if (isFanOn)
        {
            fanAudioSource.pitch = 1;
            fanAudioSource.Play();
        }
        else {
            fanAudioSource.Stop();
            fanAudioSource.clip = fanStart;
            fanAudioSource.loop = false;
            fanAudioSource.pitch = -1;
            fanAudioSource.Play();
        }
    }
}
