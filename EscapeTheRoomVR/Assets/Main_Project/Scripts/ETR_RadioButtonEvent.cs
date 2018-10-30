using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

public class ETR_RadioButtonEvent : MonoBehaviour {

    public HoverButton backwardButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.name == "Radio_Backward_Button") {
            backwardButton.gameObject.SetActive(true);
            //obj.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //obj.gameObject.AddComponent<DestroyOnDetachedFromHand>();
            Destroy(obj.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
