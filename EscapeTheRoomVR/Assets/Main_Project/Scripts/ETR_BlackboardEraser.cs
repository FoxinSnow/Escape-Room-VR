using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_BlackboardEraser : MonoBehaviour {

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
        if (collision.gameObject.tag == "BoardCover") {
            onEraserCollisionEnterEvent.Invoke();
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        {
            onEraserCollisionExitEvent.Invoke();
            //this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

}
