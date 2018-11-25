using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_BlackboardChalk : MonoBehaviour {

    public UnityEngine.Events.UnityEvent onChalkCollisionEnterEvent;
    public UnityEngine.Events.UnityEvent onChalkCollisionExitEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BoardCover") {
            onChalkCollisionEnterEvent.Invoke();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "BoardCover"){
            onChalkCollisionExitEvent.Invoke();
        }
    }

}
