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
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }
	
	// Update is called once per frame
	void Update () {
        /*
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
        */
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*") {
            isAffectedByHeat = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            Debug.Log("Affected by heat");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*")
        {
            isAffectedByHeat = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log("Not affected by heat");
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "HeatingArea")
        {
            if (isAffectedByHeat)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("Start melting");
            }
        }

        if (other.gameObject.name == "FrozenArea") {

            isAffectedByTime = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Not affected by time");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == "HeatingArea") {

            if (isAffectedByHeat)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            }
            else {

                this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            //isAffectedByTime = false;
            
            //Debug.Log("Not melting by heat");
        }

        if (other.gameObject.name == "FrozenArea")
        {
            isAffectedByTime = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log("Affected by time");
        }
    }

    public void SetIsHeating(bool isHeating) {
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
