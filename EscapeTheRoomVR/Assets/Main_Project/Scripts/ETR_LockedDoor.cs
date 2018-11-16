using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

public class ETR_LockedDoor : MonoBehaviour {

    public GameObject knob;
    public GameObject key;
    private VRTK_InteractableObject knobInteraction;
    private VRTK_InteractObjectHighlighter knobHighlight;

	// Use this for initialization
	void Start () {
        knobInteraction = knob.GetComponent<VRTK_InteractableObject>();
        knobInteraction.isUsable = false;
        knobHighlight = knob.GetComponent<VRTK_InteractObjectHighlighter>();
        knobHighlight.touchHighlight = Color.red;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key.gameObject)
        {
            knobHighlight.touchHighlight = Color.green;
            knobInteraction.isUsable = true;
            other.gameObject.SetActive(false);
            Destroy(this);
        }
    }
}
