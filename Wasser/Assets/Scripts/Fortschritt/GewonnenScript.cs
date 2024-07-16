using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GewonnenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject[] ObjekteZeigen;

    public GameObject[] ObjekteVerstecken;

    public void GewinnStatusErreicht(){
        for (int i = 0; i < ObjekteZeigen.Length; i++) {
            ObjekteZeigen[i].SetActive(true);
        }
        for (int i = 0; i < ObjekteVerstecken.Length; i++) {
             ObjekteVerstecken[i].SetActive(false);
        }
    }
}
