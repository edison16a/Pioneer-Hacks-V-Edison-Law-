using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BotPicker : MonoBehaviour
{


    public float bot = 0;
  

    public TextMeshProUGUI textBots;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bot")
        {
            Debug.Log("Collision Completed");
            Debug.Log("Detected tag");
            bot++;
            textBots.text = bot.ToString();
            Destroy(other.gameObject);
            Debug.Log("Trash destroyed");


        }
 
        
    }
}
