using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApPicker : MonoBehaviour
{


    public float Ap = 0;
  

    public TextMeshProUGUI textAps;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ap")
        {
            Debug.Log("Collision Completed");
            Debug.Log("Detected tag");
            Ap++;
            textAps.text = Ap.ToString();
            Destroy(other.gameObject);
            Debug.Log("Trash destroyed");


        }
 
        
    }
}
