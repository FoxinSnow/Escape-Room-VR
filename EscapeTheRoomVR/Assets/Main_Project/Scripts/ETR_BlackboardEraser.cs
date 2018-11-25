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
        Debug.Log("...........................");
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "BoardCover") {
            onEraserCollisionEnterEvent.Invoke();
            Debug.Log("Col with bb");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BoardCover")
        {
            onEraserCollisionExitEvent.Invoke();
            Debug.Log("Leave bb");
        }
    }

}
