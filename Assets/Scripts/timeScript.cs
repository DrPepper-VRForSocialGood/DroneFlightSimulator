using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timeScript : MonoBehaviour {
    public Text timeText;
    DateTime now = DateTime.Now;

    void Start()
    {
    }


    void Update()
    {

        timeText.text =  now.ToString("HH:mm");
    }
}
