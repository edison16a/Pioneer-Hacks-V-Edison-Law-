using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CoinPicker : MonoBehaviour
{


    public float coin = 0;
  
   
  

    public TextMeshProUGUI textCoins;

    void Start()
    {
        textCoins.text = coin.ToString() + "\n " + variableHolder.points;
    }


    private void OnTriggerEnter(Collider other)
    {
     
        
        if (other.transform.tag == "Trash")
        {
            Debug.Log("Collision Completed");
            Debug.Log("Detected tag");
            coin++;
            variableHolder.trash++;
            textCoins.text = coin.ToString() + "\n " + variableHolder.points;
            Destroy(other.gameObject);
            Debug.Log("Trash destroyed");
            //SceneManager.LoadScene(ARscene:"ARScene");
        }
 
        
    }
}
