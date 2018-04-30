using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using System.Collections;

public class DroneMovementScript : MonoBehaviour {

	Rigidbody ourDrone;
    Transform drone;


	public Text windLabel;


	void Awake(){
		ourDrone = GetComponent<Rigidbody> ();
        drone = GetComponent<Transform>();
		drone.position = new Vector3 (0, 1, 0);
		StartCoroutine (Wind ());
		
    }

    void FixedUpdate()
    {
        MovementUpDown();
        MovementForward();
        Rotation();
        ClampingSpeedValues();
        Swirl();
        ourDrone.AddRelativeForce(Vector3.up * upForce);
        ourDrone.rotation = Quaternion.Euler(new Vector3(titlAmountForward, currentYRotation, tiltAmountSideways));
    }

	IEnumerator Wind(){
		while (true){
			ourDrone.drag = MainMenu.windValue*3 + Random.Range (1.0f, 3.0f);
			windLabel.text = "Wind: " + ourDrone.drag + " mph";
            sideMovementAmount += MainMenu.windValue * 3 + Random.Range(1.0f, 3.0f);
            yield return new 
				WaitForSeconds (5);
			ourDrone.drag = MainMenu.windValue*3 + Random.Range (1.0f, 3.0f);
            sideMovementAmount += MainMenu.windValue * 3 + Random.Range(1.0f, 3.0f);
            windLabel.text = "Wind: " + ourDrone.drag + " mph";

		}
	}



    public float upForce;
	public float Speed;
	void MovementUpDown(){
		
		Speed = ourDrone.velocity.magnitude;

		if ((Mathf.Abs (Input.GetAxis ("Vertical_Right")) > 0.2f || Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f)) {
			if (Mathf.Abs(Input.GetAxis ("Vertical_Left")) > 0.2f) {
				ourDrone.velocity = ourDrone.velocity;
			}
			if (Mathf.Abs (Input.GetAxis ("Vertical_Left")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Left")) < 0.2f) {
				ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
				upForce = 16;
			}
			if (Mathf.Abs (Input.GetAxis ("Vertical_Left")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Left")) > 0.2f) {
				ourDrone.velocity = new Vector3(ourDrone.velocity.x, Mathf.Lerp(ourDrone.velocity.y, 0, Time.deltaTime * 5), ourDrone.velocity.z);
				upForce = 16;
			}
			if(Mathf.Abs (Input.GetAxis ("Horizontal_Left")) > 0.2f){
				upForce = 16;
			}
		}

		if(Mathf.Abs (Input.GetAxis("Vertical_Right")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f){
			upForce = 26;
		}
		// Set keyboard inputs for drone to lift-off and go down
		if (Input.GetAxis ("Vertical_Left") > 0.2f){
			upForce = 30;
				if(Input.GetAxis("Horizontal_Right") > 0.2f){
					upForce = 30;	
				}
		} 
		else if (Input.GetAxis ("Vertical_Left") < -0.2f){
			upForce = -26;
		} 
		else if (Mathf.Abs (Input.GetAxis ("Vertical_Left")) < 0.2f && (Mathf.Abs(Input.GetAxis("Vertical_Right")) < 0.2f && Mathf.Abs(Input.GetAxis("Horizontal_Right")) < 0.2f)){
			upForce = 12.55f;
		}

	}


	private float movementForwardSpeed = 16.0f;
	private float titlAmountForward = 0;
	private float titlVelocityForward; //unnecesary
	void MovementForward(){
		if (Input.GetAxis ("Vertical_Right") != 0) {
			ourDrone.AddRelativeForce (Vector3.forward * Input.GetAxis ("Vertical_Right") * movementForwardSpeed);
			titlAmountForward = Mathf.SmoothDamp (titlAmountForward, 20 * Input.GetAxis ("Vertical_Right"), ref titlVelocityForward, 0.1f);
		}
		else {
			titlAmountForward = Mathf.SmoothDamp (titlAmountForward, 0, ref titlVelocityForward, 0.1f);
		}
	}
	private float wantedYRotation;
	[HideInInspector]public float currentYRotation;
	private float rotateAmountByKeys = 2.5f;
	private float rotationYVelocity;
	void Rotation(){
		if (Input.GetAxis ("Horizontal_Left") < -0.2f) {
			wantedYRotation -= rotateAmountByKeys;
		}
		if(Input.GetAxis("Horizontal_Left") > 0.2f){
			wantedYRotation += rotateAmountByKeys;
		}

		currentYRotation = Mathf.SmoothDamp (currentYRotation, wantedYRotation, ref rotationYVelocity, 0.25f);
	}

	private Vector3 velocityToSmoothDampToZero;
	void ClampingSpeedValues(){
		if (Mathf.Abs (Input.GetAxis ("Vertical_Right")) > 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical_Right")) > 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Right")) < 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical_Right")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f) {
			ourDrone.velocity = Vector3.ClampMagnitude(ourDrone.velocity, Mathf.Lerp(ourDrone.velocity.magnitude, 10.0f, Time.deltaTime * 5f));
		}
		if (Mathf.Abs (Input.GetAxis ("Vertical_Right")) < 0.2f && Mathf.Abs (Input.GetAxis ("Horizontal_Right")) < 0.2f) {
			ourDrone.velocity = Vector3.SmoothDamp(ourDrone.velocity, Vector3.zero, ref velocityToSmoothDampToZero, 0.95f);
		}
	}

	private float sideMovementAmount = 16.0f;
	private float tiltAmountSideways;
	private float tiltAmountVelocity;
	void Swirl(){
		if (Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f) {
			ourDrone.AddRelativeForce (Vector3.right * Input.GetAxis ("Horizontal_Right") * sideMovementAmount);
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, -20 * Input.GetAxis ("Horizontal_Right"), ref tiltAmountVelocity, 0.1f);
		} 
		else {
			tiltAmountSideways = Mathf.SmoothDamp (tiltAmountSideways, 0, ref tiltAmountVelocity, 0.1f);
		}
	}
}
