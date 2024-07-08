using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunkteHochzaehlenButton : MonoBehaviour
{
    public PunktezaehlerScript punktezaehler; //Instanz meiner Punktezähler Klasse

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Geklickt(){
        this.punktezaehler.PunkteHochzaehlen();
    }

}
