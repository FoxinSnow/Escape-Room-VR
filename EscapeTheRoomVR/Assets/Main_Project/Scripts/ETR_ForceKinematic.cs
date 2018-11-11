using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_ForceKinematic : MonoBehaviour {

    private Rigidbody myRigibody;

    // Use this for initialization
    void Start () {
        myRigibody = this.gameObject.GetComponent<Rigidbody>();
        //myRigibody.drag = 0;
        //myRigibody.angularDrag = 0.05f;
        myRigibody.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
