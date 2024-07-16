using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorTriggerController : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter(Collider other){
        Debug.Log("Tür geöffnet.");
        if (other.CompareTag("Player")){
            this.PlayAnimation();
        }
    }

    private void OnTriggerExit(Collider other){
        Debug.Log("Tür geschlossen.");
        if (other.CompareTag("Player")){
            this.StopAnimation();
        }
    }

    public void PlayAnimation() {
        this.animator.SetTrigger("On");
    }

    public void StopAnimation() {
        this.animator.SetTrigger("Off");
    }
}
