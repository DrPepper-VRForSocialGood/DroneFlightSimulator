using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heightScript : MonoBehaviour {

	public Transform drone;
	public Text heightText;
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		double inFeet = drone.position.y * 3.28084;
		heightText.text = "H: " + inFeet.ToString("F1") + " ft";
	}
}
