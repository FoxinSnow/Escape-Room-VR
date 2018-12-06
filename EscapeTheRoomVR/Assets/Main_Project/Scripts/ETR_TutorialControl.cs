using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_TutorialControl : MonoBehaviour {

    private bool test;
    public GameObject tutorialTeleportPoint1, tutorialTeleportPoint2, tutorialTeleportPoint3;
    public GameObject tutorial1Teleport, tutorial1Trigger, tutorial1Grip;
    public GameObject tutorial2Teleport, tutorial2Grip;
    public GameObject tutorial3Teleport;
    public GameObject haloHighlight1, haloHighlight2, haloHighlight3;
    public GameObject[] freeTeleportArea;
    public GameObject[] teleportHeightAdjustmentArea;

    private float timeToFadeIn = 5;

    // Use this for initialization
    void Start () {
        tutorialTeleportPoint1.SetActive(true);
        tutorialTeleportPoint2.SetActive(false);
        tutorialTeleportPoint3.SetActive(false);
        /*
        haloHighlight1.SetActive(true);
        haloHighlight2.SetActive(false);
        haloHighlight3.SetActive(false);
        tutorial1Teleport.SetActive(true);
        tutorial1Trigger.SetActive(false);
        tutorial1Grip.SetActive(false);
        tutorial2Teleport.SetActive(false);
        tutorial2Grip.SetActive(false);
        tutorial3Teleport.SetActive(false);
        */

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
        haloHighlight3.SetActive(true);
    }

    public void TutorialStageThreeComplete() {
        tutorialTeleportPoint3.SetActive(false);
        haloHighlight3.SetActive(false);

        for (int i = 0; i < freeTeleportArea.Length; i++)
        {
            freeTeleportArea[i].gameObject.tag = "TeleportArea";
        }

        for (int i = 0; i < teleportHeightAdjustmentArea.Length; i++)
        {
            teleportHeightAdjustmentArea[i].gameObject.tag = "TeleportHeightAdjustment";
        }

    }
}
