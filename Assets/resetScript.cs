using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetScript : MonoBehaviour {
	
	public Transform drone;


	public void resetDrone(){
		drone.transform.position = Vector3.zero;


	}

}
