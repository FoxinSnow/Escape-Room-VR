﻿using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_TutorialControl : MonoBehaviour {

    private bool test;
    public GameObject tutorialTeleportPoint1, tutorialTeleportPoint2, tutorialTeleportPoint3;
    public GameObject tutorialTeleport, tutorialTrigger, tutorialGrip;
    public GameObject haloHighlight1, haloHighlight2, haloHighlight3;
    public GameObject[] freeTeleportArea;
    public GameObject[] teleportHeightAdjustmentArea;
    public GameObject headsetCollision;
    public GameObject cameraFader;

    private float timeToFadeIn = 5.0f;
    private bool faded;

    // Use this for initialization
    void Start () {
        faded = false;
        cameraFader.SetActive(true);
        tutorialTeleportPoint1.SetActive(true);
        tutorialTeleportPoint2.SetActive(false);
        tutorialTeleportPoint3.SetActive(false);
        haloHighlight1.SetActive(true);
        haloHighlight2.SetActive(false);
        haloHighlight3.SetActive(false);

        tutorialTeleport.SetActive(true);
        tutorialTrigger.SetActive(false);
        tutorialGrip.SetActive(false);
        

        for (int i = 0; i < freeTeleportArea.Length; i++) {
            freeTeleportArea[i].gameObject.tag = "Untagged";
        }
        for (int i = 0; i < teleportHeightAdjustmentArea.Length; i++)
        {
            teleportHeightAdjustmentArea[i].gameObject.tag = "Untagged";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToFadeIn > 0)
        {

            timeToFadeIn -= Time.deltaTime * 0.75f;
        }
        else
        {            
            headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().blinkTransitionSpeed = 5.0f;
            cameraFader.SetActive(false);
        }
	}

    public void TutorialStageOneComplete() {
        tutorialTeleportPoint1.SetActive(false);
        haloHighlight1.SetActive(false);
        tutorialTeleportPoint2.SetActive(true);
        haloHighlight2.SetActive(true);
    }


    public void TutorialStageTwoComplete() {
        tutorialTeleportPoint2.SetActive(false);
        haloHighlight2.SetActive(false);

        tutorialTeleportPoint3.SetActive(true);
        //haloHighlight3.SetActive(true);
    }

    public void TutorialStageThreeComplete() {
        tutorialTeleportPoint3.SetActive(false);
        //haloHighlight3.SetActive(false);

        for (int i = 0; i < freeTeleportArea.Length; i++)
        {
            freeTeleportArea[i].gameObject.tag = "TeleportArea";
        }

        for (int i = 0; i < teleportHeightAdjustmentArea.Length; i++)
        {
            teleportHeightAdjustmentArea[i].gameObject.tag = "TeleportHeightAdjustment";
        }
        Destroy(this.gameObject);
    }

    public void ShowInteractTrigger() {
        tutorialTeleport.SetActive(false);
        tutorialTrigger.SetActive(true);
        tutorialGrip.SetActive(false);
        headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().blinkTransitionSpeed = 0.1f;
    }

    public void ShowInteractGrip()
    {
        tutorialTeleport.SetActive(false);
        tutorialTrigger.SetActive(false);
        tutorialGrip.SetActive(true);
    }

    public void DisableInteractIcon()
    {
        tutorialTeleport.SetActive(false);
        tutorialTrigger.SetActive(false);
        tutorialGrip.SetActive(false);
    }
}