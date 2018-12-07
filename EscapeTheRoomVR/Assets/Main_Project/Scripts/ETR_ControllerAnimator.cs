using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ControllerAnimator : MonoBehaviour {

    private float currentScale;
    private float targetScale;
    private bool scaleToBig;
    // Use this for initialization
    void Start()
    {
        currentScale = this.gameObject.transform.localScale.x;
        targetScale = 1.25f;
        scaleToBig = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (scaleToBig)
        {
            this.gameObject.transform.localScale += new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0.5f * Time.deltaTime);
            currentScale = this.gameObject.transform.localScale.x;
            if (currentScale > targetScale)
            {
                scaleToBig = false;
            }
        }
        else
        {
            this.gameObject.transform.localScale -= new Vector3(0.5f * Time.deltaTime, 0.5f * Time.deltaTime, 0.5f * Time.deltaTime);
            currentScale = this.gameObject.transform.localScale.x;
            if (currentScale < 1.0)
            {
                scaleToBig = true;
            }
        }
    }
}
