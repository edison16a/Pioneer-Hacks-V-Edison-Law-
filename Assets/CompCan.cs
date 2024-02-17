using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompCan : MonoBehaviour
{

    public float Ap = 0;
    public float score = 0;

    public TextMeshProUGUI textAps;
    public TextMeshProUGUI textScores;



    void OnTriggerEnter(Collider other)
    {
        score = 0;
        textScores.text = score.ToString();
        Ap = 0;
        textAps.text = Ap.ToString();

    }
}
