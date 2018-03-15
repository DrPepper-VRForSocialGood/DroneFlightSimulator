using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceScript : MonoBehaviour {

	public Transform drone;
	public Text distanceText;
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (Vector3.zero, drone.position);
		double inFeet = dist * 3.28084;
		distanceText.text = "D: " + inFeet.ToString("F1") + " ft";
	}
}
