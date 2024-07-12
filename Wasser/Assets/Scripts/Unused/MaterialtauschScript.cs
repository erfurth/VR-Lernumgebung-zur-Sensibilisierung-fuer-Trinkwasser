using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialtauschScript : MonoBehaviour
{

    public Material oldMaterial;
    public Material newMaterial;


    private bool farbvertauschung = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Materialtausch()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material[] materials = renderer.sharedMaterials;

        if (farbvertauschung == false)
        {
            for (int i = 0; i < materials.Length; i++)
            {
                Debug.Log("Material " + i + " von " + gameObject + ": " + materials[i]);
                if (materials[i] == oldMaterial)
                {
                    materials[i] = newMaterial;
                    farbvertauschung = true;
                    Debug.Log("farbvertauschung = true");
                    // Debug.Log("Das Objekt " + targetObject + " hat das Material '" + oldMaterial + "' zu Material '" + newMaterial + "' gewechselt!");
                    renderer.materials = materials;
                    break;
                }

            }
        }
        else
        {

            for (int i = 0; i < materials.Length; i++)
            {
                Debug.Log("Material " + i + " von " + gameObject + ": " + materials[i]);
                if (materials[i] == newMaterial)
                {
                    materials[i] = oldMaterial;
                    farbvertauschung = false;
                    Debug.Log("farbvertauschung = false");
                    renderer.materials = materials;
                    break;
                }

            }

            
        }


    }

}
