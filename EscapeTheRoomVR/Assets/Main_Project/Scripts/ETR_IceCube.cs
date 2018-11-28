using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Coded by Yuqi Wang
public class ETR_IceCube : MonoBehaviour
{

    public GameObject key;
    private static bool isAffectedByTime;
    private static bool isInHeatingArea;
    private static bool isAffectedByHeat;
    private static float timeToMelt;
    private Animator meltingAnimator;

    // Use this for initialization
    void Start()
    {
        key.gameObject.SetActive(false);
        timeToMelt = 600;
        isAffectedByTime = true;
        isInHeatingArea = false;
        isAffectedByHeat = false;
        this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        meltingAnimator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isInHeatingArea && isAffectedByHeat)
        {
            //timeToMelt -= 60.0f * Time.deltaTime;
            //Debug.Log("Ice cube is now melting!!!!!!");
            MeltIce(60.0f, false);
            //Debug.Log("Melting progress by heat:" + timeToMelt);
        }
        else if (isAffectedByTime)
        {
            //timeToMelt -= 1.0f * Time.deltaTime;
            MeltIce(1.0f, false);
            //Debug.Log("Melting progress by time:" + timeToMelt);
            //Debug.Log("Ice cube is ONLY affected by time!");
        }
        else
        {
        }

        CheckStatus();
        meltingAnimator.Play("Melting");

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*")
        {
            isInHeatingArea = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("Affected by heat");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*")
        {
            isInHeatingArea = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log("Not affected by heat");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FrozenArea")
        {

            isAffectedByTime = false;
            this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            Debug.Log("Not affected by time");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FrozenArea")
        {
            isAffectedByTime = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            Debug.Log("Affected by time");
        }
    }

    public void ChangeHeatState()
    {
        if (isAffectedByHeat)
        {
            isAffectedByHeat = false;
            Debug.Log("Burner is on, can be affected by heat");
        }
        else
        {
            isAffectedByHeat = true;
            Debug.Log("Burner is off, cannot be affected by heat");
        }
    }


    private void CheckStatus() {
        if (timeToMelt < 0)
        {
            //this.gameObject.GetComponent<Renderer>().enabled = false;
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            key.gameObject.transform.position = this.gameObject.transform.position;
            key.SetActive(true);
            Destroy(this.gameObject);
        }
        else if (timeToMelt > 600)
        {
            timeToMelt = 600.0f;
        }
    }

    public static void MeltIce(float time, bool isAffectedByChangingTime)
    {
        if (isAffectedByTime) {
            if (isAffectedByChangingTime)
            {
                timeToMelt -= time;
            }
            else
            {
                timeToMelt -= time * Time.deltaTime;
            }
        }

        Debug.Log(timeToMelt);
    }

}
