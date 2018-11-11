using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang

public class ERT_TimeControl : MonoBehaviour {

    private double currentTime = 25200;
    public GameObject clock;
    public GameObject iceCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentTime += 1.0d * Time.deltaTime;
        Debug.Log(currentTime);
        /*
        if (!clock.gameObject.GetComponent<>().isUsing)
        {



        }
        else {

            

        }
        */
    }
}
