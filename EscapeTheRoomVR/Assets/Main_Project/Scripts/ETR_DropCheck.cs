using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ETR_DropCheck : MonoBehaviour {

    public AudioSource lockDrop;
    private Vector3 dropSpeed;
    private float speedDiff;
    private bool drop;

    // Use this for initialization
    void Start () {
        drop = false;
        dropSpeed = this.GetComponent<Rigidbody>().velocity;
        speedDiff = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (drop.Equals(false))
        {
            dropSpeed = this.GetComponent<Rigidbody>().velocity;
            speedDiff = Mathf.Abs(speedDiff - dropSpeed.y);
            Debug.Log(speedDiff);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(this.gameObject.activeSelf.Equals(true)){

            if(collision.gameObject.name.Equals("Floor_Attic") && speedDiff > 10){
                lockDrop.Play();
                Debug.Log("Play lock drop sound effect.");
                drop = true;
            }
        }
    }
}
