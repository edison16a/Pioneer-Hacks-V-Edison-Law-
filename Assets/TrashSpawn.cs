using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{

    public GameObject _organicTrash;
    public GameObject newBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        newBall = Instantiate(_organicTrash);  //Spawn a new ball from our Ball Prefab
 //Set the rotation of our new Ball
     
        
    }
}
