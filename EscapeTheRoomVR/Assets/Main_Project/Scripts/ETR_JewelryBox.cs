using System.Collections;
using System.Collections.Generic;
using VRTK;
using VRTK.Controllables.ArtificialBased;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_JewelryBox : MonoBehaviour {

    public GameObject jewelryBoxToUnlock;
    public GameObject key;
    public GameObject itemsToReveal;
    public GameObject keyReference;
    public Transform revealItemLocation;
    public AudioSource unlockSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject == key.gameObject) {
            jewelryBoxToUnlock.GetComponent<VRTK_ArtificialRotator>().enabled = true;
            jewelryBoxToUnlock.GetComponent<VRTK_InteractObjectHighlighter>().enabled = true;
            itemsToReveal.transform.position = revealItemLocation.position;
            itemsToReveal.transform.rotation = revealItemLocation.rotation;
            itemsToReveal.SetActive(true);
            if (unlockSound != null) {
                unlockSound.Play();
            }
            keyReference.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

}
