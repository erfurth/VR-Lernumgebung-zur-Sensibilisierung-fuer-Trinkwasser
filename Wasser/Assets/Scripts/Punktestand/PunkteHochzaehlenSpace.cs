using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkteHochzaehlenSpace : MonoBehaviour
{
    public PunktezaehlerScript punktezaehler; //Instanz meiner Punktezähler Klasse

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            this.punktezaehler.PunkteHochzaehlen();
        }
    }
}
