using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_MissingObject : MonoBehaviour {

    public GameObject objectToReveal;
    public GameObject objectToMatch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToMatch.gameObject) {
            objectToReveal.SetActive(true);
            other.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
