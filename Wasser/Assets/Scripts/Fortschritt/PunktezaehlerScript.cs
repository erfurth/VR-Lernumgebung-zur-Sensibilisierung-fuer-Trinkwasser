using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PunktezaehlerScript : MonoBehaviour
{
    public static PunktezaehlerScript Instance = null;

    int punktestand = 0;
    public Material onMaterial;
    public Material offMaterial;
    public GameObject[] Anzeigekugeln;


    void Awake() {
        Debug.Assert(Instance == null, "Punktezaehler already created");

        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

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
    }

}
