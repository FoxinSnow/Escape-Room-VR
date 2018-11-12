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
        /*
        for (int i = 0; i < lockObjectTransforms.Length; i++)
        {
            int currentRotation = (int)Mathf.Round(lockObjectTransforms[i].localEulerAngles.z);
            switch (currentRotation)
            {
                case -60:
                    lockObjectTransforms[i].localEulerAngles = new Vector3(0, 0, 300);
                    Debug.Log("-60 -> 300");
                    break;

                case -120:
                    lockObjectTransforms[i].localEulerAngles = new Vector3(0, 0, 240);
                    Debug.Log("-120 -> 240");
                    break;

                case -180:
                    lockObjectTransforms[i].localEulerAngles = new Vector3(0, 0, 180);
                    Debug.Log("-180 -> 180");
                    break;

            }
*/

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


        /*
        if ((int)lockObjectTransforms[i].localEulerAngles.z == unlockDegrees[i])
        {
            numberUnlocked++;
            Debug.Log("Matched" + i);
            Debug.Log("NumUnlocked" + numberUnlocked);
        }
        else
        {
            numberUnlocked = 0;
        }


    }
     */
        /*
        Debug.Log("1: " + Mathf.Round(lockObjectTransforms[0].localEulerAngles.z));
        Debug.Log("2: " + Mathf.Round(lockObjectTransforms[1].localEulerAngles.z));
        Debug.Log("3: " + Mathf.Round(lockObjectTransforms[2].localEulerAngles.z));

        if (Mathf.Round(lockObjectTransforms[0].localEulerAngles.z) == unlockDegrees[0] && Mathf.Round(lockObjectTransforms[1].localEulerAngles.z) == unlockDegrees[1] && Mathf.Round(lockObjectTransforms[2].localEulerAngles.z) == unlockDegrees[2]) {

            Debug.Log("Unlock");
        }
        */

        /*
        if (numberUnlocked == lockObjectTransforms.Length)
        {
            Debug.Log("Unlock");
        }
        */

    }

}
