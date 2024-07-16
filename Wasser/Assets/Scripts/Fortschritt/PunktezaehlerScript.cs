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
    public Material onMaterial;
    public Material offMaterial;
    public GameObject[] Anzeigekugeln;

    public TextMeshProUGUI AnzeigeText;

    public GewonnenScript GewonnenScript;

    void Awake() {
        Debug.Assert(Instance == null, "Punktezaehler already created");

        Instance = this;
    }

    public void PunkteHochzaehlen(){
        punktestand++;
        Debug.Log("Punktestand: " + punktestand);
        
        for (int i = 0; i < Anzeigekugeln.Length; i++)
        {
            Renderer r = Anzeigekugeln[i].GetComponent<Renderer>();
            
            if (i < punktestand) {
                r.sharedMaterial = onMaterial;
            }
            else {
                r.sharedMaterial = offMaterial;
            }
        }

        if (punktestand == Anzeigekugeln.Length) {
            GewonnenScript.GewinnStatusErreicht();
        }

        AnzeigeText.text = "Elemente: " + punktestand.ToString() + "/" + Anzeigekugeln.Length.ToString();
    }

    public void PunkteRunterzaehlen(){
        punktestand--;
        Debug.Log("Punktestand: " + punktestand);
        for (int i = 0; i < Anzeigekugeln.Length; i++)
        {
            Renderer r = Anzeigekugeln[i].GetComponent<Renderer>();
            
            if (i < punktestand) {
                r.sharedMaterial = onMaterial;
            }
            else {
                r.sharedMaterial = offMaterial;
            }
        }

        AnzeigeText.text = "Elemente: " + punktestand.ToString() + "/" + Anzeigekugeln.Length.ToString();
    }

}
