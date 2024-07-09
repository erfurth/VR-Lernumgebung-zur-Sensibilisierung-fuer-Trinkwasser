using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunktezaehlerScript : MonoBehaviour
{
    int punktestand = 0;
    public Material onMaterial;
    public Material offMaterial;
    public GameObject[] Anzeigekugeln;
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
