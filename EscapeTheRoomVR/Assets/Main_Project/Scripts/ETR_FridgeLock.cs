using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

// Coded by Yuqi Wang
public class ETR_FridgeLock : MonoBehaviour
{

    public GameObject fridgeDoor;
    public GameObject unlockedLock;

    public AudioSource unlockSoundEffect;
    public AudioClip failedUnlockingClip;
    public AudioClip unlockingClip;

    public Transform[] lockObjectTransforms;
    public float[] unlockDegrees;

    private VRTK_InteractableObject lockInteraction;
    private VRTK_PhysicsRotator fridgeDoorInteraction;
    private VRTK_InteractObjectHighlighter fridgeDoorHighlight;

    private int numberUnlocked;
    // Use this for initialization
    void Start()
    {
        numberUnlocked = 0;
        fridgeDoorInteraction = fridgeDoor.GetComponent<VRTK_PhysicsRotator>();
        fridgeDoorInteraction.isLocked = true;
        fridgeDoorHighlight = fridgeDoor.GetComponent<VRTK_InteractObjectHighlighter>();
        fridgeDoorHighlight.touchHighlight = Color.red;
    }

    protected virtual void OnEnable()
    {
        lockInteraction = GetComponent<VRTK_InteractableObject>();
        lockInteraction.InteractableObjectUsed += InteractableObjectUsed;
        lockInteraction.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        lockInteraction.InteractableObjectUsed -= InteractableObjectUsed;
        lockInteraction.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        CheckLock();
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {

    }

    private void CheckLock()
    {
        numberUnlocked = 0;

        for (int i = 0; i < lockObjectTransforms.Length; i++){
            int currentRotation = (int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z);
            if (currentRotation < 0){
                int newRotation = currentRotation + 360;
                lockObjectTransforms[i].localEulerAngles = new Vector3(0, 0, newRotation);
            }

            if ((int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z) == unlockDegrees[i]){

                Debug.Log(i + ":" + (int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z));

                numberUnlocked++;
            }else{
                numberUnlocked = 0;
            }
            Debug.Log(numberUnlocked);
        }

        if (numberUnlocked == lockObjectTransforms.Length)
        {
            Debug.Log("Unlock");
            fridgeDoorInteraction.isLocked = false;
            fridgeDoorHighlight.touchHighlight = Color.yellow;
            unlockSoundEffect.clip = unlockingClip;
            unlockSoundEffect.Play();
            GameObject thisLock = GameObject.Find("*Lock*");
            thisLock.SetActive(false);
            unlockedLock.gameObject.SetActive(true);
        }
        else {
            unlockSoundEffect.clip = failedUnlockingClip;
            unlockSoundEffect.Play();
        }

    }

}
