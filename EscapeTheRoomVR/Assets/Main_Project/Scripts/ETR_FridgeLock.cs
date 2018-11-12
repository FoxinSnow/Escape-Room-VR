using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_FridgeLock : MonoBehaviour
{

    public GameObject fridgeDoorToLock;
    public GameObject fridgeDoorToUnlock;
    public AudioSource unlockSoundEffect;
    public Transform[] lockObjectTransforms;
    public float[] unlockDegrees;
    private VRTK_InteractableObject interactableObject;

    private int numberUnlocked;
    // Use this for initialization
    void Start()
    {
        numberUnlocked = 0;
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
        if (unlockSoundEffect != null)
        {
            unlockSoundEffect.Play();
        }
        interactableObject.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {

    }

    private void checkLock()
    {
        for (int i = 0; i < lockObjectTransforms.Length; i++){
            int currentRotation = (int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z);
            if (currentRotation < 0){
                int newRotation = currentRotation + 360;
                lockObjectTransforms[i].localEulerAngles = new Vector3(0, 0, newRotation);
            }

            if ((int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z) == unlockDegrees[i]){
                numberUnlocked++;
            }else{
                numberUnlocked = 0;
            }
        }

        if (numberUnlocked == lockObjectTransforms.Length){
            Debug.Log("Unlock");
            fridgeDoorToUnlock.gameObject.SetActive(true);
            fridgeDoorToLock.gameObject.SetActive(false);
        }

    }

}
