using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_TutorialTrigger : MonoBehaviour {

    public UnityEngine.Events.UnityEvent teleportTriggerEvent;
    private bool triggered;
    private BoxCollider boxCollider;

    // Use this for initialization
    void Start () {
        triggered = false;
        boxCollider = this.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!boxCollider.enabled) {
            boxCollider.enabled = true;
        }

        if (boxCollider.isTrigger) {
            boxCollider.isTrigger = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (!triggered) {
                teleportTriggerEvent.Invoke();
                triggered = true;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!triggered)
            {
                teleportTriggerEvent.Invoke();
                triggered = true;
            }
        }
    }

}
