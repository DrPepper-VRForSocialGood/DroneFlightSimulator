using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDotMovement : MonoBehaviour {
	public int altitude = 120;
	public GameObject drone;
	Vector3 dronePos;
	Vector3 newPos;
	Quaternion rot = new Quaternion(0,0,0,0);

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		dronePos = drone.transform.position;
		newPos.Set(dronePos.x, altitude, dronePos.z);
		gameObject.transform.SetPositionAndRotation (newPos, rot);
	}
}
//27.1 120.9 52.2