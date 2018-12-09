using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_HighlightHaloAnimator : MonoBehaviour {


    public float minimumScale;
    public float maximumScale;

    private float currentScale;
    private float targetScale;
    private bool scaleToBig;
	// Use this for initialization
	void Start () {
        currentScale = this.gameObject.transform.localScale.x;
        scaleToBig = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (scaleToBig)
        {
            this.gameObject.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            currentScale = this.gameObject.transform.localScale.x;

            if (currentScale > maximumScale)
            {
                scaleToBig = false;
            }
        }
        else {
            this.gameObject.transform.localScale -= new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0);
            currentScale = this.gameObject.transform.localScale.x;
            if (currentScale < minimumScale)
            {
                scaleToBig = true;
            }
        }
    }
    
}
