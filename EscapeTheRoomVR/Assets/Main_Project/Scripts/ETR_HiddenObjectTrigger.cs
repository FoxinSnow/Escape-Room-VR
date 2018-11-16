using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_HiddenObjectTrigger : MonoBehaviour {

    public GameObject[] objectToReveal;
    public AudioSource hintSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player"){

            // Play a sound as the hint
            if (hintSound != null)
            {
                hintSound.Play();
            }

            // Reveal all hidden objects
            for (int i = 0; i < objectToReveal.Length; i++)
            {
                objectToReveal[i].gameObject.SetActive(true);
            }

            this.gameObject.SetActive(false);
            // Destroy the audio source and trigger since no longer required
            //Destroy(this.gameObject);

        }
    }
}
