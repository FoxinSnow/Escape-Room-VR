using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_DayNightCycle : MonoBehaviour {

    private bool isNight;
    private float currentAngle;
    // Use this for initialization
    void Start () {
        currentAngle = 180 - this.gameObject.transform.eulerAngles.x;
        Debug.Log(currentAngle);
        this.gameObject.transform.eulerAngles = new Vector3(270f, 342.640f, -10.71399f);
    }

    // Update is called once per frame
    void Update()
    {

        //float currentIntensity = this.gameObject.GetComponent<Light>().intensity;
        //float currentAngle = this.gameObject.transform.eulerAngles.x;
        //Debug.Log(currentAngle);
        //currentAngle += 2f * Time.deltaTime;
        //this.gameObject.transform.eulerAngles = new Vector3(currentAngle, 342.640f, -10.71399f);
        /*
        if (currentIntensity >= 1) {
            isNight = false;
        }else if(currentIntensity <= 0)
        {
            isNight = true;
        }

        if (isNight)
        {
            float newIntensity = currentIntensity += (1.0f / 180.0f) * Time.deltaTime;
            if (newIntensity >= 1)
            {
                this.gameObject.GetComponent<Light>().intensity = 1;
            }
            else
            {
                this.gameObject.GetComponent<Light>().intensity = newIntensity;
            }
        }
        else {
            float newIntensity = currentIntensity -= (1.0f / 180.0f) * Time.deltaTime;
            if (newIntensity <= 0)
            {
                this.gameObject.GetComponent<Light>().intensity = 0;
            }
            else
            {
                this.gameObject.GetComponent<Light>().intensity = newIntensity;
            }

        }
        Debug.Log(currentIntensity);
        
	}
    */
    }
}
