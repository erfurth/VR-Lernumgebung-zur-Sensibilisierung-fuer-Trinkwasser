using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using System.Diagnostics.CodeAnalysis;

public class PunktezaehlerScript : MonoBehaviour
{
    public static PunktezaehlerScript Instance = null;

    int punktestand = 0;

    // ---Für Material ändern---
    // public Material onMaterial;
    // public Material offMaterial;
    public GameObject[] AnzeigeObjekte;

    public TextMeshProUGUI AnzeigeText;

    public GewonnenScript GewonnenScript;

    void Awake() {
        Debug.Assert(Instance == null, "Punktezaehler already created");
        Instance = this;
    }

    public void PunkteHochzaehlen(){
        punktestand++;
        Debug.Log("Punktestand: " + punktestand);
        
        for (int i = 0; i < AnzeigeObjekte.Length; i++)
        {
            // Renderer r = AnzeigeObjekte[i].GetComponent<Renderer>();
            // if (i < punktestand) {
            //     r.sharedMaterial = onMaterial;
            // }
            // else {
            //     r.sharedMaterial = offMaterial;
            // }

            if (i < punktestand) {
                AnzeigeObjekte[i].SetActive(true);
            }
            else {
                AnzeigeObjekte[i].SetActive(false);
            }
        }

        if (punktestand == AnzeigeObjekte.Length) {
            GewonnenScript.GewinnStatusErreicht();
        }

        AnzeigeText.text = "Elemente: " + punktestand.ToString() + "/" + AnzeigeObjekte.Length.ToString();
    }

    public void PunkteRunterzaehlen(){
        punktestand--;
        Debug.Log("Punktestand: " + punktestand);
        for (int i = 0; i < AnzeigeObjekte.Length; i++)
        {
            // Renderer r = AnzeigeObjekte[i].GetComponent<Renderer>();
            // if (i < punktestand) {
            //     r.sharedMaterial = onMaterial;
            // }
            // else {
            //     r.sharedMaterial = offMaterial;
            // }

            if (i < punktestand) {
                AnzeigeObjekte[i].SetActive(true);
            }
            else {
                AnzeigeObjekte[i].SetActive(false);
            }
        }

        AnzeigeText.text = "Elemente: " + punktestand.ToString() + "/" + AnzeigeObjekte.Length.ToString();
    }

}
