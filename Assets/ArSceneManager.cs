//Standard Unity/C# functionality
using UnityEngine;

//These tell our project to use pieces from the Lightship ARDK
using System.Collections;
using System.Collections.Generic;
using Niantic.ARDK.AR;
using Niantic.ARDK.AR.ARSessionEventArgs;
using Niantic.ARDK.Utilities;
using Niantic.ARDK.Utilities.Input.Legacy;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

//Define our main class
public class ArSceneManager : MonoBehaviour
{
    //Variables we'll need to reference other objects in our game

    public GameObject _ballPrefab;

    public GameObject _organicTrash;  //This will store the -Ball- trash Prefab we created earlier, so we can spawn a new Ball whenever we want
    public GameObject _trashTrash;
    public GameObject _recycleTrash;
    private GameObject upNext;
    public int randomNum = 1;

    private float time = 0f;

    public Camera _mainCamera;  //This will reference the MainCamera in the scene, so the ARDK can leverage the device camera
    IARSession _ARsession;  //An ARDK ARSession is the main piece that manages the AR experience

    public float coin = 0;
    public TextMeshProUGUI textCoins;



    // Start is called before the first frame update
    void Start()
    {
        //ARSessionFactory helps create our AR Session. Here, we're telling our 'ARSessionFactory' to listen to when a new ARSession is created, then call an 'OnSessionInitialized' function when we get notified of one being created
        ARSessionFactory.SessionInitialized += OnSessionInitialized;
        randomNum = Random.Range(1, 4);

        upNext = showUpNext(); //Spawns the trash which will come next and assigns it to a variable
    }

    // Update is called once per frame
    void Update()
    {
        updateUpNext(upNext);
        //If there is no touch, we're not going to do anything
        if (PlatformAgnosticInput.touchCount <= 0)
        {
            return;
        }

        //If we detect a new touch, call our 'TouchBegan' function
        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {

            TouchBegan(touch);
        }
    }

    //This function will be called when a new AR Session has been created, as we instructed our 'ARSessionFactory' earlier
    private void OnSessionInitialized(AnyARSessionInitializedArgs args)
    {
        //Now that we've initiated our session, we don't need to do this again so we can remove the callback
        ARSessionFactory.SessionInitialized -= OnSessionInitialized;

        //Here we're saving our AR Session to our '_ARsession' variable, along with any arguments our session contains
        _ARsession = args.Session;
    }

    //This function will be called when the player touches the screen. For us, we'll have this trigger the shooting of our ball from where we touch.
    private void TouchBegan(Touch touch)
    {
        //Let's spawn a new ball to bounce around our space
        Destroy(upNext);

        variableHolder.trash--;
        //textCoins.text = variableHolder.trash + "\n " + variableHolder.points;

        GameObject newBall;

        switch (randomNum)
        {
            case 1:
                newBall = Instantiate(_organicTrash);  //Spawn a new ball from our Ball Prefab
                newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            case 2:
                newBall = Instantiate(_trashTrash);  //Spawn a new ball from our Ball Prefab
                newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            case 3:
                newBall = Instantiate(_recycleTrash);  //Spawn a new ball from our Ball Prefab
                newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            default:
                newBall = Instantiate(_ballPrefab);  //Spawn a new ball from our Ball Prefab
                newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
        }

        /*GameObject newBall = Instantiate(_ballPrefab);  //Spawn a new ball from our Ball Prefab
        newBall.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
        newBall.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;*/    //Set the position of our new Ball to just in front of our Main Camera

        //Add velocity to our Ball, here we're telling the game to put Force behind the Ball in the direction Forward from our Camera (so, straight ahead)
        Rigidbody rigbod = newBall.GetComponent<Rigidbody>();
        rigbod.velocity = new Vector3(0f, 0f, 0f);
        float force = 300.0f;
        rigbod.AddForce(_mainCamera.transform.forward * force);

        //Pick a new trash type
        randomNum = Random.Range(1, 4);

        //Show the new trash type
        upNext = showUpNext();
    }

    private GameObject showUpNext()
    {
        time = 0f;
        GameObject upNext;

        switch (randomNum)
        {
            case 1:
                upNext = Instantiate(_organicTrash);  //Spawn a new ball from our Ball Prefab
                upNext.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                upNext.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            case 2:
                upNext = Instantiate(_trashTrash);  //Spawn a new ball from our Ball Prefab
                upNext.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                upNext.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            case 3:
                upNext = Instantiate(_recycleTrash);  //Spawn a new ball from our Ball Prefab
                upNext.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                upNext.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
            default:
                upNext = Instantiate(_ballPrefab);  //Spawn a new ball from our Ball Prefab
                upNext.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));   //Set the rotation of our new Ball
                upNext.transform.position = _mainCamera.transform.position + _mainCamera.transform.forward;
                break;
        }

        return upNext;
    }

    private void updateUpNext(GameObject upNext)
    {
        time += Time.deltaTime;
        //upNext.transform.rotation = _mainCamera.transform.rotation + Quaternion.Euler(new Vector3(0.0f, 3.0f, 0.0f));   //Set the rotation of our new Ball
        upNext.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
        upNext.transform.position = Vector3.Lerp((_mainCamera.transform.position + _mainCamera.transform.forward - _mainCamera.transform.up), _mainCamera.transform.position + _mainCamera.transform.forward, EaseOut(time / 1.5f));
        
        //Add timer///////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        if (variableHolder.trash < 0)
        {
            for(float i = 0f; i < 5f; i += Time.deltaTime)
            {

            }
            SceneManager.LoadScene("TrashGame");
        }
    }
    private float EaseOut(float k)
    {
        return 1f + ((k -= 1f) * k * k);
    }
}
