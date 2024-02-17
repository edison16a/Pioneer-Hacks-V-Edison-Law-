using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrashSend : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {


        if (other.transform.tag == "TrashCan")
        {

            SceneManager.LoadScene("ARscene");


        }


    }

        // Start is called before the first frame update
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
