using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_DayNightCycle : MonoBehaviour {

    private bool isNight;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        //float currentIntensity = this.gameObject.GetComponent<Light>().intensity;
        float rotateDegree = 12f * Time.deltaTime;
        this.gameObject.transform.Rotate(rotateDegree, 0, 0);
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
