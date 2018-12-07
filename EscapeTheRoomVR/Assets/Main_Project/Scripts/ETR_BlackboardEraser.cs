using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_BlackboardEraser : MonoBehaviour {

    public Collider wipeCollider;
    public UnityEngine.Events.UnityEvent onEraserCollisionEnterEvent;
    public UnityEngine.Events.UnityEvent onEraserCollisionExitEvent;
    public UnityEngine.Events.UnityEvent onEraserGrabbedEvent;
    public UnityEngine.Events.UnityEvent onEraserUngrabbedEvent;
    public UnityEngine.Events.UnityEvent eraserEvent;

    private VRTK_InteractableObject interactableObject;
    private bool isDialoguePlayed;
    private bool isGrabbed;

    // Use this for initialization
    void Start () {
        isDialoguePlayed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!isGrabbed) {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
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
        onEraserGrabbedEvent.Invoke();
        isGrabbed = true;
    }

    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        onEraserUngrabbedEvent.Invoke();
        isGrabbed = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider contactCollider = collision.contacts[0].thisCollider;
        if (collision.gameObject.tag == "BoardCover" && contactCollider == wipeCollider) {
            Debug.Log("Collided");
            onEraserCollisionEnterEvent.Invoke();
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BoardCover"){
            onEraserCollisionExitEvent.Invoke();
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            if (!isDialoguePlayed) {
                eraserEvent.Invoke();
                isDialoguePlayed = true;
            }
        }
    }

}
