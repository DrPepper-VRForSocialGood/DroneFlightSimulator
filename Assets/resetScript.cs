using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetScript : MonoBehaviour {
	
	public Transform drone;
	void Start () {
		GameObject.Find ("H").GetComponentInChildren<Text>().text = "";
	}

	public void resetDrone(){
		drone.transform.position = Vector3.zero;


	}

}
