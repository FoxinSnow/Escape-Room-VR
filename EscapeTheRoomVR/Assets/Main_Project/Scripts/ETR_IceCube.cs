using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;


// Coded by Yuqi Wang
public class ETR_IceCube : MonoBehaviour
{

    public GameObject key;
    private static bool isAffectedByTime;
    private static bool isInHeatingArea;
    private static bool isAffectedByHeat;
    private static float timeToMelt;
    private static bool isGrabbed;
    private Animation meltingAnimation;
    private VRTK_InteractableObject iceCubeInteraction;

    // Use this for initialization
    void Start()
    {
        key.gameObject.SetActive(false);
        timeToMelt = 600;
        isAffectedByTime = true;
        isInHeatingArea = false;
        isAffectedByHeat = false;
        meltingAnimation = this.GetComponent<Animation>();
        meltingAnimation["Take 001"].speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Experiemental
        Vector2 velocity = this.GetComponent<Rigidbody>().velocity;

        if (!isGrabbed && velocity.magnitude == 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, this.gameObject.transform.rotation.y, 0);
        }

        // 
        if (isInHeatingArea && isAffectedByHeat)
        {
            MeltIce(20.0f, false);
        }
        else if (isAffectedByTime)
        {
            MeltIce(1.0f, false);
        }
        else
        {
        }

        CheckStatus();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*")
        {
            isInHeatingArea = true;
            Debug.Log("Affected by heat");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "*Bowl*")
        {
            isInHeatingArea = false;
            Debug.Log("Not affected by heat");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FrozenArea")
        {

            isAffectedByTime = false;
            Debug.Log("Not affected by time");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FrozenArea")
        {
            isAffectedByTime = true;
            Debug.Log("Affected by time");
        }
    }

    public static void ChangeHeatState()
    {
        if (isAffectedByHeat)
        {
            isAffectedByHeat = false;
            Debug.Log("Burner is on, can be affected by heat");
        }
        else
        {
            isAffectedByHeat = true;
            Debug.Log("Burner is off, cannot be affected by heat");
        }
    }

    private void CheckStatus() {
        if (timeToMelt < 0)
        {
            //this.gameObject.GetComponent<Renderer>().enabled = false;
            //this.gameObject.GetComponent<BoxCollider>().enabled = false;
            key.gameObject.transform.position = this.gameObject.transform.position;
            key.SetActive(true);
            Destroy(this.gameObject);
        }
        else if (timeToMelt > 600)
        {
            timeToMelt = 600.0f;
        }
        else {
            meltingAnimation["Take 001"].normalizedTime =(600 - timeToMelt)/600;
            meltingAnimation.Play();
        }
    }

    public static void MeltIce(float time, bool isAffectedByChangingTime)
    {
        if (isAffectedByTime) {
            if (isAffectedByChangingTime)
            {
                timeToMelt -= time;
            }
            else
            {
                timeToMelt -= time * Time.deltaTime;
            }
        }
        //Debug.Log("Melting Ice: Seconds remaining:" + timeToMelt);
    }


    protected virtual void OnEnable()
    {
        iceCubeInteraction = this.GetComponent<VRTK_InteractableObject>();
        iceCubeInteraction.InteractableObjectGrabbed += InteractableObjectGrabbed;
        iceCubeInteraction.InteractableObjectUngrabbed += InteractableObjectUngrabbed;
    }

    protected virtual void OnDisable()
    {
        iceCubeInteraction.InteractableObjectGrabbed -= InteractableObjectGrabbed;
        iceCubeInteraction.InteractableObjectUngrabbed -= InteractableObjectUngrabbed;
    }

    protected virtual void InteractableObjectGrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = true;
    }


    protected virtual void InteractableObjectUngrabbed(object sender, InteractableObjectEventArgs e)
    {
        isGrabbed = false;
    }


}
