using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenesend : MonoBehaviour
{
    // Method to handle button click

    
    public void Click()
    {
        SceneManager.LoadScene("AppIconsScene");
    } 

}