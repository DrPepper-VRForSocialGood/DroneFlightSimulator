using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCams : MonoBehaviour
{
    public GameObject DroneCam, PilotCam;
    public RenderTexture render;
    public bool camSwitch = false;
    public Canvas UI;

    void Start()
    {
        UI.enabled = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            camSwitch = !camSwitch;
            if (camSwitch == false)    //drone view
            {
                PilotCam.GetComponent<Camera>().enabled = false;
                DroneCam.GetComponent<Camera>().enabled = true;
                UI.enabled = true;
                DroneCam.GetComponent<Camera>().targetTexture = null;
                
            }

            if (camSwitch == true)  //pilot view
            {
                DroneCam.GetComponent<Camera>().enabled = false;
           
                PilotCam.GetComponent<Camera>().enabled = true;
   
                UI.enabled = false;
                DroneCam.GetComponent<Camera>().targetTexture = render;

            }


        }
    }
}





