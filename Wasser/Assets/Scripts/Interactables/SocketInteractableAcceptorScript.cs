using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketInteractableAcceptorScript : MonoBehaviour
{
    public MeshRenderer SocketRenderer;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(SocketRenderer != null, "Socket Renderer not set", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void OnObjectEntered(SelectEnterEventArgs args) {
        if(args.interactableObject is XRGrabInteractable grabInteractable) {
            InteractableScript interactable = grabInteractable.gameObject.GetComponent<InteractableScript>();

            Debug.Assert(interactable != null, "Socket got non-interactable gameobject", interactable);

            interactable.EnterSocket(this, args);
        }
    }

    
    public void OnObjectExited(SelectExitEventArgs args) {
        if(args.interactableObject is XRGrabInteractable grabInteractable) {
            InteractableScript interactable = grabInteractable.gameObject.GetComponent<InteractableScript>();

            Debug.Assert(interactable != null, "Socket left non-interactable gameobject", interactable);

            interactable.ExitSocket(this, args);
        }
    }

    public void HideSocket() {
        this.SocketRenderer.enabled = false;
    }

    public void ShowSocket() {
        this.SocketRenderer.enabled = true;
    }
}
