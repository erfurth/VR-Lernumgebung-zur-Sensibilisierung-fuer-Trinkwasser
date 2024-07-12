using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketBeschreibungScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void OnObjectEntered(SelectEnterEventArgs args)
    {   
      XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null)
        {
            text.text = grabInteractable.GetComponent<InteractableBeschreibungScript>().Anzeigetext;
        }     
    }
    public void OnObjectExited(SelectExitEventArgs args)
    {
       XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null)
        {
            text.text = "";
        }     
    }
}
