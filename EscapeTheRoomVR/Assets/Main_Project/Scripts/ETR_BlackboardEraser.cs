using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_BlackboardEraser : MonoBehaviour {

    public Collider wipeCollider;
    public UnityEngine.Events.UnityEvent onEraserCollisionEnterEvent;
    public UnityEngine.Events.UnityEvent onEraserCollisionExitEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision collision)
    {

        Collider contactCollider = collision.contacts[0].thisCollider;

        Debug.Log(contactCollider);

        if (collision.gameObject.tag == "BoardCover" && contactCollider == wipeCollider) {
            onEraserCollisionEnterEvent.Invoke();
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BoardCover"){
            onEraserCollisionExitEvent.Invoke();
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
