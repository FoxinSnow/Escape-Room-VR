using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

// Coded by Yuqi Wang

public class ETR_RadioEvent : MonoBehaviour {

    public HoverButton forwardButton;
    public HoverButton pauseButton;
    public HoverButton playButton;
    public HoverButton backwardButton;
    public HoverButton ejectButton;
    public AudioSource audioSource;
    public AudioClip forwardAudioClip;
    public AudioClip backwardAudioClip;

    private void Start()
    {
        forwardButton.onButtonDown.AddListener(OnForwardButtonDown);

        pauseButton.onButtonDown.AddListener(OnPauseButtonDown);

        playButton.onButtonDown.AddListener(OnPlayButtonDown);

        backwardButton.onButtonDown.AddListener(OnBackwardButtonDown);

        ejectButton.onButtonDown.AddListener(OnEjectButtonDown);

        audioSource.clip = forwardAudioClip;

    }

    private void OnForwardButtonDown(Hand hand)
    {
        audioSource.clip = forwardAudioClip;
    }

    private void OnPauseButtonDown(Hand hand)
    {
        audioSource.Pause();
    }

    private void OnBackwardButtonDown(Hand hand)
    {
        audioSource.clip = backwardAudioClip;
    }

    private void OnEjectButtonDown(Hand hand) {

    }

    private void OnPlayButtonDown(Hand hand) {
        audioSource.Play();
    }
}
