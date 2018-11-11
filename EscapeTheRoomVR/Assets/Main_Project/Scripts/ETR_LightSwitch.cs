using System.Collections;
using System.Collections.Generic;
using VRTK;
using UnityEngine;

// Coded by Yuqi Wang

public class ETR_LightSwitch : MonoBehaviour
{
    //public HoverButton hoverButton;
    public GameObject[] lightList;
    public AudioSource switchSoundEffect;
    private VRTK_InteractableObject interactableObject;

    public void Start()
    {
        int lightNumber = lightList.Length;

    }

    protected virtual void OnEnable()
    {
        interactableObject = GetComponent<VRTK_InteractableObject>();
        interactableObject.InteractableObjectUsed += InteractableObjectUsed;
        interactableObject.InteractableObjectUnused += InteractableObjectUnused;
    }

    protected virtual void OnDisable()
    {
        interactableObject.InteractableObjectUsed -= InteractableObjectUsed;
        interactableObject.InteractableObjectUnused -= InteractableObjectUnused;
    }

    protected virtual void Update()
    {}

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("Triggered");
        SwitchLight();
        if (switchSoundEffect != null)
        {
            switchSoundEffect.Play();
        }
        float degree = this.gameObject.transform.localEulerAngles.y;
        Debug.Log(degree);
        this.gameObject.transform.localEulerAngles = new Vector3(0, -degree , 0);
        interactableObject.enabled = false;
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        Debug.Log("NOT Triggered");
    }

    private void SwitchLight()
    {
        int lightNumber = lightList.Length;

        if (lightNumber != 0) {

            for (int i = 0; i < lightNumber; i++) {

                if (!lightList[i].activeSelf)
                {
                    lightList[i].SetActive(true);
                }
                else {
                    lightList[i].SetActive(false);
                }

            }

        }
    }

}
