using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
    public GameObject correctObject; // Gewünschtes Objekt
    public GameObject[] ToggleObjectState; 
    private XRSocketInteractor socketInteractor;
    private void Awake() //aufgerufen, bevor das Spielt gestartet wird
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
        if (socketInteractor == null)
        {
            Debug.LogError("Kein XRSocketInteractor auf diesem GameObject");
        }

        for (int i = 0; i < ToggleObjectState.Length; i++)
        {
            ToggleObjectState[i].SetActive(false);
        }
    }

    public void OnObjectEntered(SelectEnterEventArgs args)
    {   
        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null && grabInteractable.gameObject == correctObject)
        {         
            //Debug.Log("Das korrekte Objekt wurde in den Socket gelegt");
            AnimationScript animationScript = grabInteractable.gameObject.GetComponent<AnimationScript>();

            if (animationScript != null){
                //Debug.Log("Checker: spielt ab!");
                animationScript.Abspielen();
            }
            for (int i = 0; i < ToggleObjectState.Length; i++)
            {
                Debug.Log("ToggleObjectState[i].SetActive(true) + Object:",ToggleObjectState[i]);
                ToggleObjectState[i].SetActive(true);
            }
        }     
    }
    public void OnObjectExited(SelectExitEventArgs args)
    {
        XRGrabInteractable grabInteractable = args.interactableObject as XRGrabInteractable;
        if (grabInteractable != null && grabInteractable.gameObject == correctObject)
        {
            //Debug.Log("Das korrekte Objekt wurde aus dem Socket entfernt");
            AnimationScript animationScript = grabInteractable.gameObject.GetComponent<AnimationScript>();
            
            if (animationScript != null){
                //Debug.Log("Checker: spielt nicht mehr ab!");
                animationScript.Abspielen(); // Stoppt die Animation
            }

            for (int i = 0; i < ToggleObjectState.Length; i++)
            {
                Debug.Log("ToggleObjectState[i].SetActive(false) + Object:",ToggleObjectState[i]);
                ToggleObjectState[i].SetActive(false);
            }

        }
    }
}
