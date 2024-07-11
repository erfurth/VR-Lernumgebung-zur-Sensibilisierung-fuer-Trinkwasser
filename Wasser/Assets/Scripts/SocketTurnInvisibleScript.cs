using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketTurnInvisibleScript : MonoBehaviour
{
    public MeshRenderer renderer;
    public void OnObjectEntered()
    {
        renderer.enabled = false;
    }

    // (Optional) Funktion, um das ursprüngliche Material wiederherzustellen
    public void OnObjectExited()
    {
        renderer.enabled = true;
    }
}
