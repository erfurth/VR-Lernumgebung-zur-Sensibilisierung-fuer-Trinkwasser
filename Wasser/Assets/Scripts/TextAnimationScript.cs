using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimationScript : MonoBehaviour
{
    private TextMeshProUGUI scanningText; // Dein Textfeld im Unity-Editor zuweisen
    public float time = 1f; // Dauer pro Punkt (in Sekunden)
    int dotCount = 0;

    public void Start(){
        scanningText = GetComponent<TextMeshProUGUI>();
    }
    public void Update(){
        time += Time.deltaTime;
        if (time > 1){
            scanningText.text = "scannt" + new string('.', dotCount);
            dotCount = (dotCount + 1) % 4; // 0, 1, 2, 3 Punkte
            time = 0;
        }
    }
}
