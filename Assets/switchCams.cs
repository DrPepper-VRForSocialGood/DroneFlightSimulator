using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCams : MonoBehaviour
{
    public GameObject DroneCam, PilotCam;
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
            if (camSwitch == true)
            {
                PilotCam.SetActive(false);
                DroneCam.SetActive(true);
                UI.enabled = true;
                
            }

            if (camSwitch == false)
            {
                DroneCam.SetActive(false);
                PilotCam.SetActive(true);
                UI.enabled = false;
                

            }
        }
    }
}





