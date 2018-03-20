using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCams : MonoBehaviour
{
    public GameObject DroneCam, PilotCam;
    public KeyCode TKey;
    public bool camSwitch = false;
    public Canvas UI;

    void Start()
    {
        UI.enabled = false;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!camSwitch)
            {                                 
                camSwitch = true;
                PilotCam.SetActive(false);
                DroneCam.SetActive(true);
                UI.enabled = true;
            
            }
            else if (camSwitch)
            {
                PilotCam.SetActive(true);
                DroneCam.SetActive(false);
                camSwitch = false;
                UI.enabled = false;
            }

        }
    }
}





