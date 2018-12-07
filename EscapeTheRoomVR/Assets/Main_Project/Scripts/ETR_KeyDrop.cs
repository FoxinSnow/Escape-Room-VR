using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_KeyDrop : MonoBehaviour {

    public AudioSource keyDropSound;
    public UnityEngine.Events.UnityEvent keyEvent;
    private bool played;
	// Use this for initialization
	void Start () {
        played = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor_Attic") {
            if (!played)
            {
                keyDropSound.Play();
                played = true;
                keyEvent.Invoke();
            }
        }
    }
}
