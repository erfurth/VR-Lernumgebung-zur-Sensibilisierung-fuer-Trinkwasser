using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInteractionsScript : MonoBehaviour
{
    public InteractableScript[] Interactables;
    
    void Start()
    {
    }

    public void TransformationReset(){
        Debug.Log("TransformationReset()");
        for (int i = 0; i < Interactables.Length; i++)
        {
            Interactables[i].ResetInteractable();
        }
    }

    public void TransformationResetOnGround(){
        Debug.Log("TransformationReset()");
        for (int i = 0; i < Interactables.Length; i++)
        {
            Interactables[i].ResetInteractableOnGround();
        }
    }

    public void ToggleBeschriftungen(Toggle value){
        for (int i = 0; i < Interactables.Length; i++)
        {
            if(value.isOn) {
                Interactables[i].ShowAssociatedGameObjects();
            } else {
                Interactables[i].HideAssociatedGameObjects();
            }
        }
    }

}
