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
		double jjj;
		jjj=Mathf.Sqrt(Mathf.Pow(drone.velocity.x,2)+Mathf.Pow(drone.velocity.z,2));
		hsText.text = "HS: " + jjj.ToString("F1") + " mph";
	}
}
