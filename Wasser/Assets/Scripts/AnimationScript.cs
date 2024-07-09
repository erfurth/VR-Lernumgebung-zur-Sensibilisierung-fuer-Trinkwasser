using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    
    public Animator animator;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        // Debug.Log("animator: " + animator);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Abspielen()
    {     
        Debug.Log("Abspielen()");
        if (activated == false) {
            animator.SetTrigger("On");
            activated = true;
            Debug.Log("Trigger on");
        }
        else {
            animator.SetTrigger("Off");
            activated = false;
            Debug.Log("Trigger off");
        }

    }
}


