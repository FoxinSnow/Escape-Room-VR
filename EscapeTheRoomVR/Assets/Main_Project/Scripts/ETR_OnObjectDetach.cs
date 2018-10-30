using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class OnObjectDetach : MonoBehaviour
    {
        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {
            Debug.Log("Detttt");
        }
    }
}