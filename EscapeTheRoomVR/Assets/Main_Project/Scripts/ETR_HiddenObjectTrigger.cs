using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_HiddenObjectTrigger : MonoBehaviour {

    public AudioSource hintSound;
    public UnityEngine.Events.UnityEvent floorPieceEvent;
    private bool canPlayHintSound;
    private float hintSoundPlayDelay;
    private bool hasBeenUsed;
    private VRTK_InteractableObject interactableObject;

    private bool isDialoguePlayed;

	// Use this for initialization
	void Start () {
        isDialoguePlayed = false;
        canPlayHintSound = true;
        hintSoundPlayDelay = 0;
        hasBeenUsed = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (hintSoundPlayDelay > 0)
        {
            hintSoundPlayDelay -= Time.deltaTime;
        }
        else if (hintSoundPlayDelay <= 0) {
            hintSoundPlayDelay = 0;
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player"){

            // Play a sound as the hint
            if (canPlayHintSound && hintSound != null)
            {
                if (!hintSound.isPlaying && hintSoundPlayDelay == 0) {
                    hintSound.Play();
                    hintSoundPlayDelay = 5;

                    if (!isDialoguePlayed) {
                        floorPieceEvent.Invoke();
                        isDialoguePlayed = true;
                    }
                }     
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FloorPieceArea") {
            Debug.Log("Can play hint sound");
            canPlayHintSound = true;
        }


        if (other.gameObject.tag == "Player")
        {

            // Play a sound as the hint
            if (canPlayHintSound && hintSound != null)
            {
                if (!hintSound.isPlaying && hintSoundPlayDelay == 0)
                {
                    hintSound.Play();
                    hintSoundPlayDelay = 5;

                    if (!isDialoguePlayed)
                    {
                        floorPieceEvent.Invoke();
                        isDialoguePlayed = true;
                    }
                }
            }
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FloorPieceArea")
        {
            Debug.Log("Cant play hint sound!");
            canPlayHintSound = false;
            Destroy(other.gameObject);
        }
    }

    protected virtual void OnEnable()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectGrabbed += InteractableObjectGrabbed;
        interactableObject.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
    }

    protected virtual void OnDisable()
    {
        interactableObject.InteractableObjectGrabbed -= InteractableObjectGrabbed;
        interactableObject.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
    }


    protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        if (!hasBeenUsed) {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            hasBeenUsed = true;
        }    
    }

    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
    }
}
