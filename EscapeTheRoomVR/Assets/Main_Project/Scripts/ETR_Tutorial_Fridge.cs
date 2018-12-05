using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_Tutorial_Fridge : MonoBehaviour {

    public UnityEngine.Events.UnityEvent fridgeEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        fridgeEvent.Invoke();
        this.gameObject.SetActive(false);
    }


}
