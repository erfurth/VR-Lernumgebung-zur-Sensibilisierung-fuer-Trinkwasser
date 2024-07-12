using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketTurnInvisibleScript : MonoBehaviour
{
    public MeshRenderer myRenderer;
    public void OnObjectEntered()
    {
        myRenderer.enabled = false;
    }

    // (Optional) Funktion, um das ursprüngliche Material wiederherzustellen
    public void OnObjectExited()
    {
        myRenderer.enabled = true;
    }
}
