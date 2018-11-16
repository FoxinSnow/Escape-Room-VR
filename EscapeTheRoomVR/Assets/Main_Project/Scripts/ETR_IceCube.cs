using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Coded by Yuqi Wang
public class ETR_IceCube : MonoBehaviour {

    public GameObject key;
    private bool isAffectedByTime;
    private bool isAffectedByHeat;

	// Use this for initialization
	void Start () {
        key.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*") {
            isAffectedByHeat = true;
            Debug.Log("Affected by time");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isAffectedByHeat = false;
        Debug.Log("Not affected by heat");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FrozenArea") {

            isAffectedByTime = false;
            Debug.Log("Affected by time");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FrozenArea")
        {
            isAffectedByTime = false;
            Debug.Log("Not affected by time");
        }
    }
}
