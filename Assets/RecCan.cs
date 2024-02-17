using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecCan : MonoBehaviour
{

    public float bot = 0;
    public float score = 0;

    public TextMeshProUGUI textBots;
    public TextMeshProUGUI textScores;



    void OnTriggerEnter(Collider other)
    {

        bot = 0;
        textBots.text = bot.ToString();
        score++;
        textScores.text = score.ToString();
    }
}
