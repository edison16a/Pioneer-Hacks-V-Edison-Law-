using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCan : MonoBehaviour
{


    public float coin = 0;
    public float score = 0;

    public TextMeshProUGUI textCoins;
    public TextMeshProUGUI textScores;



    void OnTriggerEnter(Collider other)
    {

        coin = 0;
        textCoins.text = coin.ToString();
        score++;
        textScores.text = score.ToString();
    }
}
