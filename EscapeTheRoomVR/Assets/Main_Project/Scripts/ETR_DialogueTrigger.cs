using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_DialogueTrigger : MonoBehaviour {

    public string colliderTag;
    public UnityEngine.Events.UnityEvent dialogueTriggerEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(colliderTag))
        {
            dialogueTriggerEvent.Invoke();
            Destroy(this.gameObject);
        }
    }
}
