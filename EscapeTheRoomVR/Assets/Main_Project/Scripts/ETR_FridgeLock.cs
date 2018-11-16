using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.PhysicsBased;
using UnityEngine;

public class ETR_FridgeLock : MonoBehaviour
{

    public GameObject fridgeDoorToLock;
    public GameObject fridgeDoorToUnlock;
    public GameObject unlockedLock;
    public AudioSource unlockSoundEffect;
    public AudioClip failedUnlockingClip;
    public AudioClip unlockingClip;
    public Transform[] lockObjectTransforms;
    public float[] unlockDegrees;
    private VRTK_InteractableObject interactableObject;
    private VRTK_BasePhysicsControllable fridgeDoor;

    private int numberUnlocked;
    // Use this for initialization
    void Start()
    {
        numberUnlocked = 0;
        fridgeDoor = fridgeDoorToUnlock.GetComponent<VRTK_BasePhysicsControllable>();
    }

    protected virtual void OnEnable()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectUsed += InteractableObjectUsed;
        interactableObject.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        interactableObject.InteractableObjectUsed -= InteractableObjectUsed;
        interactableObject.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        checkLock();
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {

    }

    private void checkLock()
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

            unlockSoundEffect.clip = unlockingClip;
            unlockSoundEffect.Play();

            fridgeDoorToUnlock.gameObject.SetActive(true);
            fridgeDoorToLock.gameObject.SetActive(false);
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
