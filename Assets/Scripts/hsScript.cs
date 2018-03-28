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

		double absValue = Mathf.Abs (Mathf.Sqrt(Mathf.Pow((float)drone.velocity.x,2)+ Mathf.Pow((float)drone.velocity.z,2)));
		hsText.text = "HS: " + absValue.ToString("F1") + " mph";
	}
}
