using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformationResetter : MonoBehaviour
{
    public GameObject[] Interactables; 
    private Vector3[] initialPositions;
    private Quaternion[] initialRotations;
    private Vector3[] initialScales;
    
    void Start()
    {
        // Initialisierung der Arrays mit der gleichen Länge wie Interactables
        initialPositions = new Vector3[Interactables.Length];
        initialRotations = new Quaternion[Interactables.Length];
        initialScales = new Vector3[Interactables.Length];

        // Speichern der Anfangstransformationen
        for (int i = 0; i < Interactables.Length; i++)
        {
            initialPositions[i] = Interactables[i].transform.position;
            initialRotations[i] = Interactables[i].transform.rotation;
            initialScales[i] = Interactables[i].transform.localScale;
        }
    }

    public void TransformationReset(){
        Debug.Log("TransformationReset()");
        for (int i = 0; i < Interactables.Length; i++)
        {
            Interactables[i].transform.position = initialPositions[i];
            Interactables[i].transform.rotation = initialRotations[i];
            Interactables[i].transform.localScale = initialScales[i];
        }
    }

}
