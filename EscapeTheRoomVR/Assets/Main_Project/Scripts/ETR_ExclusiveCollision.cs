using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coded by Yuqi Wang
public class ETR_ExclusiveCollision : MonoBehaviour {

    public string gameObjectTag;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag != gameObjectTag) {
            Physics.IgnoreCollision(collision.collider, this.gameObject.GetComponent<Collider>());
        }
    }
}
