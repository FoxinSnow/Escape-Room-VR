using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;
using VRTK.Controllables.PhysicsBased;

// Coded by Yuqi Wang
public class ETR_FridgeLock : MonoBehaviour
{

    public GameObject fridgeDoorToUnlock;
    public GameObject lockedLock;
    public GameObject unlockedLock;
    public GameObject fridgeDialogueTrigger;

    public AudioSource unlockSoundEffect;
    public AudioClip failedUnlockingClip;
    public AudioClip unlockingClip;
    public AudioSource lockDropSoundEffect;

    public Transform[] lockObjectTransforms;
    public float[] unlockDegrees;

    private VRTK_InteractableObject lockInteraction;

    private int numberUnlocked;
    // Use this for initialization
    void Start()
    {
        numberUnlocked = 0;
        fridgeDialogueTrigger.SetActive(false);
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
            fridgeDoorToUnlock.GetComponent<VRTK_PhysicsRotator>().enabled = true;
            fridgeDoorToUnlock.GetComponent<VRTK_InteractObjectHighlighter>().enabled = true;
            fridgeDialogueTrigger.SetActive(true);
            unlockSoundEffect.clip = unlockingClip;
            unlockSoundEffect.Play();
            lockDropSoundEffect.Play();
            lockedLock.gameObject.SetActive(false);  
            unlockedLock.gameObject.SetActive(true);
        }
        else {
            unlockSoundEffect.clip = failedUnlockingClip;
            unlockSoundEffect.Play();
        }

    }

}
