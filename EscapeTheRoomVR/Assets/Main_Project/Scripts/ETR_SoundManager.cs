using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_SoundManager : MonoBehaviour {

    public AudioSource ambienceAudioSource;
    public AudioClip morningClip, dayClip, nightClip;

    public AudioSource safeAudioSource;
    public AudioClip safeButton, safeButtonConfirm, safeUnlock;

    public AudioSource fanAudioSource;
    public AudioClip fanStart, fanRun;

    public AudioSource switchAudioSource;
    public AudioSource burnerAudioSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    public void PlayBurnerSoundEffect() {
        if (burnerAudioSource.isPlaying){
            burnerAudioSource.Stop();
        }
        else{
            burnerAudioSource.Play();
        } 
    }
}
