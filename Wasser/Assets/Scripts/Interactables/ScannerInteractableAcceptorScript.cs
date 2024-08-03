using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ScannerInteractableAcceptorScript : MonoBehaviour
{
    public MeshRenderer SocketRenderer;
    public TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(Text != null, "Text not set for scanner", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnObjectEntered(SelectEnterEventArgs args) {
        if(args.interactableObject is XRGrabInteractable grabInteractable) {
            InteractableScript interactable = grabInteractable.gameObject.GetComponent<InteractableScript>();

            Debug.Assert(interactable != null, "ScannerSocket got non-interactable gameobject", interactable);

            this.Text.text = interactable.Text;
            this.HideSocket();
        }
    }

    
    public void OnObjectExited(SelectExitEventArgs args) {
        if(args.interactableObject is XRGrabInteractable grabInteractable) {
            InteractableScript interactable = grabInteractable.gameObject.GetComponent<InteractableScript>();

            Debug.Assert(interactable != null, "ScannerSocket left non-interactable gameobject", interactable);

            this.Text.text = "";
            this.ShowSocket();
        }
    }

    public void HideSocket() {
        this.SocketRenderer.enabled = false;
    }

    public void ShowSocket() {
        this.SocketRenderer.enabled = true;
    }
}
