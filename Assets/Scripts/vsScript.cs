using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vsScript : MonoBehaviour {

	public Rigidbody drone;
	public Text vsText;

	void Start () {
	}


	void Update () {
		
		double absValue = Mathf.Abs ((float)drone.velocity.y);
		vsText.text = "VS: " + absValue.ToString("F1") + " mph";
	}
}
