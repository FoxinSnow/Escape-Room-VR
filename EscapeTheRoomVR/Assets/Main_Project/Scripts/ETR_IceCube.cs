using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Coded by Yuqi Wang
public class ETR_IceCube : MonoBehaviour {

    public GameObject key;
    private bool isAffectedByTime;
    private bool isAffectedByHeat;
    private bool isHeating;
    private float timeToMelt;

	// Use this for initialization
	void Start () {
        key.gameObject.SetActive(false);
        timeToMelt = 600;
	}
	
	// Update is called once per frame
	void Update () {
        if (isAffectedByHeat && isHeating)
        {
            timeToMelt -= 10.0f * Time.deltaTime;
        }
        else if (isAffectedByTime)
        {

        }
        else if (isAffectedByHeat)
        {

        }
        else {

            timeToMelt -= 1.0f * Time.deltaTime;
        }
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

    public void GetIsHeating(bool isHeating) {
        this.isHeating = isHeating;
    }

    public void MeltIce(float time) {
        float currentStatus = timeToMelt - time;
        if (currentStatus < 0)
        {
            key.SetActive(true);
            Destroy(this);
        }
        else if (currentStatus > 600) {
            timeToMelt = 600.0f;
        }

    }
}
