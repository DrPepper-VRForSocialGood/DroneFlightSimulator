using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class crashScript : MonoBehaviour {
    bool isCrashed = false;
    public GameObject crashScreen; 
    public GameObject redScreen;
    public GameObject UI;
    private DroneMovementScript daScript;
    private switchCams obj;
    Transform drone;
    Rigidbody ourDrone;


    // Use this for initialization
    void Start () {
        isCrashed = false;
        drone = GetComponent<Transform>();
        ourDrone = GetComponent<Rigidbody>();
        obj = GetComponentInChildren<switchCams>();
        daScript = GetComponent<DroneMovementScript>();
        daScript.enabled = true;
        ourDrone.useGravity = true;
        redScreen.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
        if (isCrashed == true)
        {
            crashScreen.SetActive(true);
            UI.SetActive(false);
            redScreen.SetActive(false);
            daScript.enabled = false;
            ourDrone.useGravity = false;
           obj.camSwitch = false;


            if (Input.anyKeyDown)
            {
                isCrashed = false;
                SceneManager.LoadScene("MainMenu");
                Debug.Log("load menu");
            }
        }

        else
        {
            Time.timeScale = 1f;
            redScreen.SetActive(true);
            crashScreen.SetActive(false);
            UI.SetActive(true);
        }

    }
    void OnCollisionEnter(Collision collision)
    {

        if (Time.time > 5)
        {
            isCrashed = true;
            Time.timeScale = 0.5f;
            drone.position = new Vector3(0, 1, 0);
  

        }
    }
}

