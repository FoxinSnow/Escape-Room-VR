using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_TutorialControl : MonoBehaviour {

    public GameObject tutorialTeleportPoint1, tutorialTeleportPoint2, tutorialTeleportPoint3;
    public GameObject tutorialTeleport, tutorialTrigger, tutorialGrip, tutorialGrip2;
    public GameObject haloHighlight1, haloHighlight2, haloHighlight3;
    public GameObject tutorialInstructionTeleport, tutorialInstructionTrigger, tutorialInstructionGrip, tutorialInstructionGrip2;
    public GameObject[] freeTeleportArea;
    public GameObject[] teleportHeightAdjustmentArea;

    public GameObject dialogueTriggerGroup;

    public GameObject headsetCollision;
    public GameObject cameraFader;

    public UnityEngine.Events.UnityEvent tutorialEvent;

    private float timeToFadeIn = 3.0f;
    private bool faded;
    private bool isDialoguePlayed;

    // Use this for initialization
    void Start () {
        isDialoguePlayed = false;
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
        tutorialGrip2.SetActive(false);

        tutorialInstructionTeleport.SetActive(true);
        tutorialInstructionTrigger.SetActive(false);
        tutorialInstructionGrip.SetActive(false);
        tutorialInstructionGrip2.SetActive(false);

        for (int i = 0; i < freeTeleportArea.Length; i++) {
            freeTeleportArea[i].gameObject.tag = "Untagged";
        }
        for (int i = 0; i < teleportHeightAdjustmentArea.Length; i++)
        {
            teleportHeightAdjustmentArea[i].gameObject.tag = "Untagged";
        }

        dialogueTriggerGroup.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (timeToFadeIn > 0)
        {

            timeToFadeIn -= Time.deltaTime * 0.75f;
        }
        else
        {
            if (!isDialoguePlayed) {
                tutorialEvent.Invoke();
                isDialoguePlayed = true;
            }       
            headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().blinkTransitionSpeed = 3.0f;
            cameraFader.SetActive(false);
        }
	}

    public void TutorialStageOneComplete() {
        tutorialTeleportPoint1.SetActive(false);
        haloHighlight1.SetActive(false);
        tutorialTeleportPoint2.SetActive(true);
        haloHighlight2.SetActive(true);
        tutorialGrip2.SetActive(true);
        tutorialInstructionGrip2.SetActive(true);
    }


    public void TutorialStageTwoComplete() {
        tutorialTeleportPoint2.SetActive(false);
        haloHighlight2.SetActive(false);
        tutorialGrip2.SetActive(false);
        tutorialInstructionGrip2.SetActive(false);
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
        dialogueTriggerGroup.SetActive(true);
        Destroy(this.gameObject);
    }

    public void ShowInteractTrigger() {
        tutorialTeleport.SetActive(false);
        tutorialInstructionTeleport.SetActive(false);
        tutorialTrigger.SetActive(true);
        tutorialInstructionTrigger.SetActive(true);
        tutorialGrip.SetActive(false);
        tutorialInstructionGrip.SetActive(false);
        headsetCollision.GetComponent<VRTK_HeadsetCollisionFade>().blinkTransitionSpeed = 0.1f;
    }

    public void ShowInteractGrip()
    {
        tutorialTeleport.SetActive(false);
        tutorialInstructionTeleport.SetActive(false);
        tutorialTrigger.SetActive(false);
        tutorialInstructionTrigger.SetActive(false);
        tutorialGrip.SetActive(true);
        tutorialInstructionGrip.SetActive(true);
    }

    public void DisableInteractIcon()
    {
        tutorialTeleport.SetActive(false);
        tutorialInstructionTeleport.SetActive(false);
        tutorialTrigger.SetActive(false);
        tutorialInstructionTrigger.SetActive(false);
        tutorialGrip.SetActive(false);
        tutorialInstructionGrip.SetActive(false);
    }
}
