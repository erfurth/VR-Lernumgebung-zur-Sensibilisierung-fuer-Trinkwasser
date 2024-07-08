using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PunktezaehlerScript : MonoBehaviour
{
    int punktestand = 0;

    public Text punktestandText;

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
        punktestandText.text = punktestand.ToString() + " / 100";
        Debug.Log("Punktestand: " + punktestand);
    }

}
