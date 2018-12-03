using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_DropCheck : MonoBehaviour {

    public AudioSource lockDrop; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.activeSelf.Equals(true)){
            if(collision.gameObject.name.Equals("Floor_Attic")){
                lockDrop.Play();
                Debug.Log("Play lock drop sound effect.");
            }
        }
    }
}
