using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hsScript : MonoBehaviour {

	public Rigidbody drone;
	public Text hsText;

	void Start () {
	}


	void Update () {

		double absValue = Mathf.Abs ((float)drone.velocity.x);
		hsText.text = "HS: " + absValue.ToString("F1") + " mph";
	}
}
