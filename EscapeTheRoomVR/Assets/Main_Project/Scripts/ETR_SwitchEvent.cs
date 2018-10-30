using System.Collections;
using System.Collections.Generic;
using Valve.VR.InteractionSystem;
using UnityEngine;

// Coded by Yuqi Wang

public class ETR_SwitchEvent : MonoBehaviour
{
    public HoverButton hoverButton;
    public GameObject[] lightList;

    private void Start()
    {
        hoverButton.onButtonDown.AddListener(OnButtonDown);
    }

    private void OnButtonDown(Hand hand)
    {
        SwitchLight();
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
