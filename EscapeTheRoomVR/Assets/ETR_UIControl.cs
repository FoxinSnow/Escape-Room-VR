using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_UIControl : MonoBehaviour {

    public GameObject subtitle;
    public float subtitileFade;
    private bool isShowing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isShowing) {


            // subtitle value ++

            if (subtitileFade == 1.0f) {
                isShowing = false;
            }

        }
	}

    void DisplaySubtitle(string info) {



        isShowing = true;
    }



}
