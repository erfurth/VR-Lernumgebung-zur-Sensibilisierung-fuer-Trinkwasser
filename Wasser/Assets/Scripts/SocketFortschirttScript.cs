using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketFortschirttScript : MonoBehaviour
{
public GameObject correctObject; // Objekt
    private XRSocketInteractor socketInteractor;

    private int Fortschritt = 0;
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
            Fortschritt++;
            Debug.Log("Fortschritt++. Fortschritt = " + Fortschritt);
        }     
    }
    public void OnObjectExited(SelectExitEventArgs args)
    {
        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null && grabInteractable.gameObject == correctObject)
        {
            // Das korrekte Objekt wurde aus dem Socket entfernt
            Fortschritt--;
            Debug.Log("Fortschritt--. Fortschritt = " + Fortschritt);
        }
    }
}
