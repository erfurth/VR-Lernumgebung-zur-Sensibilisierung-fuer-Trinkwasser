using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class InteractableScript : MonoBehaviour
{
    public string Text;
    public bool HasAnimation = false;
    public GameObject CorrectSocket;

    public GameObject[] AssociatedGameObjects;

    public Toggle Toggle;

    private bool isCorrectSocketed = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;
    private Transform initialParentTransform;

    private Animator animator;

    private GameObject currentSocket = null;

    public void Start() {
        this.initialPosition = this.transform.position;
        this.initialRotation = this.transform.rotation;
        this.initialScale = this.transform.localScale;
        this.initialParentTransform = this.transform.parent;

        if (this.HasAnimation) {
            this.animator = GetComponent<Animator>();

            Debug.Assert(this.animator != null, "Gameobject should have Animator");
        }

        this.HideAssociatedGameObjects();
    }

    public void EnterSocket(SocketInteractibleAcceptorScript socketInteractible, SelectEnterEventArgs args) {
        if (socketInteractible.gameObject == this.CorrectSocket) {
            Debug.Log("Entered correct Socket", this.gameObject);
            this.isCorrectSocketed = true;

            this.PlayAnimation();
            this.ShowAssociatedGameObjects();
            socketInteractible.HideSocket();
            PunktezaehlerScript.Instance.PunkteHochzaehlen();
        } else {
            Debug.Log("Wrong socket", this.gameObject);
        }

        this.currentSocket = socketInteractible.gameObject;
        this.currentSocket.GetComponent<SphereCollider>().enabled = false;
    }

    public void ExitSocket(SocketInteractibleAcceptorScript socketInteractible, SelectExitEventArgs args) {
        Debug.Log("Left Socket", this.gameObject);
        bool wasInCorrectSocket = this.isCorrectSocketed;
        this.HideAssociatedGameObjects();
        this.StopAnimation();
        this.isCorrectSocketed = false;
        socketInteractible.ShowSocket();
        if (wasInCorrectSocket) {
        PunktezaehlerScript.Instance.PunkteRunterzaehlen();
        }
        

        StartCoroutine("reactivateSocket");
    }

    public void PlayAnimation() {
        if(this.HasAnimation) {
            this.animator.ResetTrigger("Off");
            this.animator.SetTrigger("On");
            Debug.Log("Animation On", this.gameObject);
        }
    }

    public void StopAnimation() {
        if(this.HasAnimation) {
            this.animator.ResetTrigger("On");
            this.animator.SetTrigger("Off");
            Debug.Log("Animation Off", this.gameObject);
        }
    }

    public void ShowAssociatedGameObjects(){
        if (Toggle.isOn){
            if (this.isCorrectSocketed) {
                for (int i = 0; i < this.AssociatedGameObjects.Length; i++)
                {
                    this.AssociatedGameObjects[i].SetActive(true);
                }
            }
        }

    }

    public void HideAssociatedGameObjects() {
        for (int i = 0; i < this.AssociatedGameObjects.Length; i++)
        {
            this.AssociatedGameObjects[i].SetActive(false);
        }
    }

    public void ResetInteractable() {
        if (this.currentSocket != null) {
            StartCoroutine("reactivateSocket");
            
            XRSocketInteractor interactor = this.currentSocket.GetComponent<XRSocketInteractor>();
            IXRSelectInteractable interactable = this.GetComponent<IXRSelectInteractable>();
            interactor.interactionManager.SelectExit(interactor, interactable);
            Debug.Log("Unsocketed for Reset");
        }

        this.transform.position = this.initialPosition;
        this.transform.rotation = this.initialRotation;
        this.transform.localScale = this.initialScale;

        // this.transform.SetParent(this.initialParentTransform);
        Debug.Log("Unsocketed for Reset Done");
    }

    public void ResetInteractableOnGround() {
        if (this.currentSocket != null) {
            return;
        }

        this.transform.position = this.initialPosition;
        this.transform.rotation = this.initialRotation;
        this.transform.localScale = this.initialScale;

        // this.transform.SetParent(this.initialParentTransform);
        Debug.Log("Unsocketed for Reset Done");
    }

    IEnumerator reactivateSocket() {
        yield return new WaitForSeconds(0.5f);


        Debug.Log("reactivateSocket");
        if (this.currentSocket != null) {
            this.currentSocket.GetComponent<SphereCollider>().enabled = true;
            this.currentSocket = null;
            Debug.Log("Done");
        }
    }
}
