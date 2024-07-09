using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
    public GameObject correctObject; // Objekt
    private XRSocketInteractor socketInteractor;
    private void Awake() //aufgerufen, bevor das Spielt gestartet wird
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        if (socketInteractor == null)
        {
            Debug.LogError("Kein XRSocketInteractor auf diesem GameObject");
        }
    }

    public void OnObjectEntered(SelectEnterEventArgs args)
    {   
        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null && grabInteractable.gameObject == correctObject)
        {
            // Das korrekte Objekt wurde in den Socket gelegt
            Debug.Log("Das korrekte Objekt wurde in den Socket gelegt");
            AnimationScript animationScript = grabInteractable.gameObject.GetComponent<AnimationScript>();
            Debug.Log("Checker: spielt ab!");
            animationScript.Abspielen();
        }     
    }
    public void OnObjectExited(SelectExitEventArgs args)
    {
        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null && grabInteractable.gameObject == correctObject)
        {
            // Das korrekte Objekt wurde aus dem Socket entfernt
            Debug.Log("Das korrekte Objekt wurde aus dem Socket entfernt");
            AnimationScript animationScript = grabInteractable.gameObject.GetComponent<AnimationScript>();
            Debug.Log("Checker: spielt nicht mehr ab!");
            animationScript.Abspielen(); // Stoppt die Animation
        }
    }
}
