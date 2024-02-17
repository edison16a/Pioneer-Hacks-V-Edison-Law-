using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.SceneManagement;

public class SendBack : MonoBehaviour
{


    public float coin = 0;

    public TextMeshProUGUI textCoins;

    void OnTriggerEnter(Collider other)
    {
        variableHolder.points++;

        textCoins.text = "\n " + variableHolder.points;
    }
}

/*if (variableHolder.trash <= 0)
        {
            SceneManager.LoadScene("TrashGame");
        }*/
//SceneManager.LoadScene("TrashGame");