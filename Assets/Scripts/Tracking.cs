using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tracking : MonoBehaviour {
	public GameObject firstObject;
	public GameObject secondObject;
	public GameObject thirdObject;
	public GameObject fourthObject;
	public GameObject fifthObject;
	public GameObject sixthObject;
	public GameObject seventhObject;
	public GameObject eightObject;
	public GameObject ninthObject;
	public GameObject tenthObject;
	public GameObject elventhObject;
	public GameObject twelvethObject;
	public GameObject thirdteenthObject;
	public GameObject fourteenthObject;
	public GameObject fifthteenthObject;
	public GameObject sixthteenthObject;
	public GameObject seventeenthObject;
	public GameObject eightteenthObject;

	// 3D vector that defines the closest drone collider point to nthobject
	Vector3 closestSurface1_1;
	Vector3 closestSurface1_2;
	Vector3 closestSurface1_3;
	Vector3 closestSurface1_4;
	Vector3 closestSurface1_5;
	Vector3 closestSurface1_6;
	Vector3 closestSurface1_7;
	Vector3 closestSurface1_8;
	Vector3 closestSurface1_9;
	Vector3 closestSurface1_10;
	Vector3 closestSurface1_11;
	Vector3 closestSurface1_12;
	Vector3 closestSurface1_13;
	Vector3 closestSurface1_14;
	Vector3 closestSurface1_15;
	Vector3 closestSurface1_16;
	Vector3 closestSurface1_17;
	Vector3 closestSurface1_18;

	// 3D vector that defines the closest nthobject collider point to the drone  
	Vector3 closestSurface_1;
	Vector3 closestSurface_2;
	Vector3 closestSurface_3;
	Vector3 closestSurface_4;
	Vector3 closestSurface_5;
	Vector3 closestSurface_6;
	Vector3 closestSurface_7;
	Vector3 closestSurface_8;
	Vector3 closestSurface_9;
	Vector3 closestSurface_10;
	Vector3 closestSurface_11;
	Vector3 closestSurface_12;
	Vector3 closestSurface_13;
	Vector3 closestSurface_14;
	Vector3 closestSurface_15;
	Vector3 closestSurface_16;
	Vector3 closestSurface_17;
	Vector3 closestSurface_18;
	Vector3 droneposition;

	// Variables for Safety Sphere Radius around the drone
	public int Safe_Radius_1 = 2;
	public int Safe_Radius_2 = 5;
	public int Safe_Radius_3 = 10;
	public int Safe_Radius_4 = 15;

	// Variables for the Color displayed for each Safety Sphere
	public Color Safe_Radius_1_Color;
	public Color Safe_Radius_2_Color;
	public Color Safe_Radius_3_Color;
	public Color Safe_Radius_4_Color;

	// Auxiliary variables for counting and holding the object colors
	private int count;
	private string dp;
	private string objectcolor;

    //Variables for red screen flash
    public int numFlashes = 4;
    public float flashSpeed = 0.5f;
    public Color flashColor = new Color(255, 0, 0, 90);
    public Image redImage;

    // Use this for initialization
    void Start () {
        redImage.color = Color.clear; 
	}
	
	// Update is called once per frame
	void Update () {
		
		// position of my drone on a frame by frame basis
		droneposition = transform.position;
		dp = droneposition.ToString ("G4");
		WriteFile ();

		//  these functions determine the surface point of the drone collider that is closer to the position of the nth collider
		closestSurface1_1 = GetComponent<Collider>().ClosestPointOnBounds(firstObject.transform.position);
		closestSurface1_2 = GetComponent<Collider>().ClosestPointOnBounds(secondObject.transform.position);
		closestSurface1_3 = GetComponent<Collider>().ClosestPointOnBounds(thirdObject.transform.position);
		closestSurface1_4 = GetComponent<Collider>().ClosestPointOnBounds(fourthObject.transform.position);
		closestSurface1_5 = GetComponent<Collider>().ClosestPointOnBounds(fifthObject.transform.position);
		closestSurface1_6 = GetComponent<Collider>().ClosestPointOnBounds(sixthObject.transform.position);
		closestSurface1_7 = GetComponent<Collider>().ClosestPointOnBounds(seventhObject.transform.position);
		closestSurface1_8 = GetComponent<Collider>().ClosestPointOnBounds(eightObject.transform.position);
		closestSurface1_9 = GetComponent<Collider>().ClosestPointOnBounds(ninthObject.transform.position);
		closestSurface1_10 = GetComponent<Collider>().ClosestPointOnBounds(tenthObject.transform.position);
		closestSurface1_11 = GetComponent<Collider>().ClosestPointOnBounds(elventhObject.transform.position);
		closestSurface1_12 = GetComponent<Collider>().ClosestPointOnBounds(twelvethObject.transform.position);
		closestSurface1_13 = GetComponent<Collider>().ClosestPointOnBounds(thirdteenthObject.transform.position);
		closestSurface1_14 = GetComponent<Collider>().ClosestPointOnBounds(fourteenthObject.transform.position);
		closestSurface1_15 = GetComponent<Collider>().ClosestPointOnBounds(fifthteenthObject.transform.position);
		closestSurface1_16 = GetComponent<Collider>().ClosestPointOnBounds(sixthteenthObject.transform.position);
		closestSurface1_17 = GetComponent<Collider>().ClosestPointOnBounds(seventeenthObject.transform.position);
		closestSurface1_18 = GetComponent<Collider>().ClosestPointOnBounds(eightteenthObject.transform.position);

		// these functions determine the surface point of the nthObject collider that is closer to the position the drone collider
		closestSurface_1 = firstObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_2 = secondObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_3 = thirdObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_4 = fourthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_5 = fifthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_6 = sixthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_7 = seventhObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_8 = eightObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_9 = ninthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_10 = tenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_11 = elventhObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_12 = twelvethObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_13 = thirdteenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_14 = fourteenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_15 = fifthteenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_16 = sixthteenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_17 = seventeenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
		closestSurface_18 = eightteenthObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);

		// the distance between the surfaces of the 2 colliders
		float surfaceDistance_1 = Vector3.Distance(closestSurface1_1, closestSurface_1);
		float surfaceDistance_2 = Vector3.Distance(closestSurface1_2, closestSurface_2);
		float surfaceDistance_3 = Vector3.Distance(closestSurface1_3, closestSurface_3);
		float surfaceDistance_4 = Vector3.Distance(closestSurface1_4, closestSurface_4);
		float surfaceDistance_5 = Vector3.Distance(closestSurface1_5, closestSurface_5);
		float surfaceDistance_6 = Vector3.Distance(closestSurface1_6, closestSurface_6);
		float surfaceDistance_7 = Vector3.Distance(closestSurface1_7, closestSurface_7);
		float surfaceDistance_8 = Vector3.Distance(closestSurface1_8, closestSurface_8);
		float surfaceDistance_9 = Vector3.Distance(closestSurface1_9, closestSurface_9);
		float surfaceDistance_10 = Vector3.Distance(closestSurface1_10, closestSurface_10);
		float surfaceDistance_11 = Vector3.Distance(closestSurface1_11, closestSurface_11);
		float surfaceDistance_12 = Vector3.Distance(closestSurface1_12, closestSurface_12);
		float surfaceDistance_13 = Vector3.Distance(closestSurface1_13, closestSurface_13);
		float surfaceDistance_14 = Vector3.Distance(closestSurface1_14, closestSurface_14);
		float surfaceDistance_15 = Vector3.Distance(closestSurface1_15, closestSurface_15);
		float surfaceDistance_16 = Vector3.Distance(closestSurface1_16, closestSurface_16);
		float surfaceDistance_17 = Vector3.Distance(closestSurface1_17, closestSurface_17);
		float surfaceDistance_18 = Vector3.Distance(closestSurface1_18, closestSurface_18);

		// IF statement that defines the condition to be check for each safe radius and the color to be displayed/stored
		if (surfaceDistance_1 <= Safe_Radius_1 || surfaceDistance_2 <= Safe_Radius_1 || surfaceDistance_3 <= Safe_Radius_1 || surfaceDistance_4 <= Safe_Radius_1 || surfaceDistance_5 <= Safe_Radius_1 || surfaceDistance_6 <= Safe_Radius_1 || surfaceDistance_7 <= Safe_Radius_1 || surfaceDistance_8 <= Safe_Radius_1 || surfaceDistance_9 <= Safe_Radius_1 || surfaceDistance_10 <= Safe_Radius_1 || surfaceDistance_11 <= Safe_Radius_1 || surfaceDistance_12 <= Safe_Radius_1 || surfaceDistance_13 <= Safe_Radius_1 || surfaceDistance_14 <= Safe_Radius_1 || surfaceDistance_15 <= Safe_Radius_1 || surfaceDistance_16 <= Safe_Radius_1 || surfaceDistance_17 <= Safe_Radius_1 || surfaceDistance_18 <= Safe_Radius_1) {
			gameObject.GetComponent<Renderer>().material.color = Safe_Radius_1_Color;
			objectcolor = "Red";
            StartCoroutine(FlashRed());
        }
		else if (surfaceDistance_1 <= Safe_Radius_2 || surfaceDistance_2 <= Safe_Radius_2 || surfaceDistance_3 <= Safe_Radius_2 || surfaceDistance_4 <= Safe_Radius_2 || surfaceDistance_5 <= Safe_Radius_2 || surfaceDistance_6 <= Safe_Radius_2 || surfaceDistance_7 <= Safe_Radius_2 || surfaceDistance_8 <= Safe_Radius_2 || surfaceDistance_9 <= Safe_Radius_2 || surfaceDistance_10 <= Safe_Radius_2 || surfaceDistance_11 <= Safe_Radius_2 || surfaceDistance_12 <= Safe_Radius_2 || surfaceDistance_13 <= Safe_Radius_2 || surfaceDistance_14 <= Safe_Radius_2 || surfaceDistance_15 <= Safe_Radius_2 || surfaceDistance_16 <= Safe_Radius_2 || surfaceDistance_17 <= Safe_Radius_2 || surfaceDistance_18 <= Safe_Radius_2) {
			gameObject.GetComponent<Renderer>().material.color = Safe_Radius_2_Color;
			objectcolor = "Orange";
            redImage.color = Color.clear;
        }
        else if (surfaceDistance_1 <= Safe_Radius_3 || surfaceDistance_2 <= Safe_Radius_3 || surfaceDistance_3 <= Safe_Radius_3 || surfaceDistance_4 <= Safe_Radius_3 || surfaceDistance_5 <= Safe_Radius_3 || surfaceDistance_6 <= Safe_Radius_3 || surfaceDistance_7 <= Safe_Radius_3 || surfaceDistance_8 <= Safe_Radius_3 || surfaceDistance_9 <= Safe_Radius_3 || surfaceDistance_10 <= Safe_Radius_3 || surfaceDistance_11 <= Safe_Radius_3 || surfaceDistance_12 <= Safe_Radius_3 || surfaceDistance_13 <= Safe_Radius_3 || surfaceDistance_14 <= Safe_Radius_3 || surfaceDistance_15 <= Safe_Radius_3 || surfaceDistance_16 <= Safe_Radius_3 || surfaceDistance_17 <= Safe_Radius_3 || surfaceDistance_18 <= Safe_Radius_3){ 
			gameObject.GetComponent<Renderer>().material.color = Safe_Radius_3_Color;
			objectcolor = "Yellow";
            redImage.color = Color.clear;

        }
        else if (surfaceDistance_1 > Safe_Radius_4 || surfaceDistance_2 > Safe_Radius_4 || surfaceDistance_3 > Safe_Radius_4 || surfaceDistance_4 > Safe_Radius_4 || surfaceDistance_5 > Safe_Radius_4 || surfaceDistance_6 > Safe_Radius_4 || surfaceDistance_7 > Safe_Radius_4 || surfaceDistance_8 > Safe_Radius_4 || surfaceDistance_9 > Safe_Radius_4 || surfaceDistance_10 > Safe_Radius_4 || surfaceDistance_11 > Safe_Radius_4 || surfaceDistance_12 > Safe_Radius_4 || surfaceDistance_13 > Safe_Radius_4 || surfaceDistance_14 > Safe_Radius_4 || surfaceDistance_15 > Safe_Radius_4 || surfaceDistance_16 > Safe_Radius_4 || surfaceDistance_17 > Safe_Radius_4 || surfaceDistance_18 > Safe_Radius_4){ 
			gameObject.GetComponent<Renderer>().material.color = Safe_Radius_4_Color;
			objectcolor = "Green";
            redImage.color = Color.clear;

        }

        //		 Debugging statements to visualize the distances between objects, color at a given time, and distance 
        //Debug.Log ("My current color is:" + objectcolor);
        //				Debug.Log(surfaceDistance1+" :surface1");
        //				Debug.Log(surfaceDistance2+" :surface2");
        //				Debug.Log(surfaceDistance2+" :surface3");
        //				Debug.DrawLine(transform.position, firstObject.transform.position, Color.yellow);
        //				Debug.DrawLine(transform.position, secondObject.transform.position, Color.yellow);
        //				Debug.DrawLine(transform.position, thirdObject.transform.position, Color.yellow);
        //				Debug.DrawLine(closestSurface1_1, closestSurface_1, Color.magenta);
        //				Debug.DrawLine(closestSurface1_2, closestSurface_2, Color.magenta);
        //				Debug.DrawLine(closestSurface1_3, closestSurface_3, Color.magenta);
        //				Debug.DrawLine(closestSurface1_4, closestSurface_4, Color.magenta);
        //				Debug.DrawLine(closestSurface1_5, closestSurface_5, Color.magenta);
        //				Debug.DrawLine(closestSurface1_6, closestSurface_6, Color.magenta);
        //				Debug.DrawLine(closestSurface1_7, closestSurface_7, Color.magenta);
        //				Debug.DrawLine(closestSurface1_8, closestSurface_8, Color.magenta);
        //				Debug.DrawLine(closestSurface1_9, closestSurface_9, Color.magenta);
        //				Debug.DrawLine(closestSurface1_10, closestSurface_10, Color.magenta);
        //				Debug.DrawLine(closestSurface1_11, closestSurface_11, Color.magenta);
        //				Debug.DrawLine(closestSurface1_12, closestSurface_12, Color.magenta);
        //				Debug.DrawLine(closestSurface1_13, closestSurface_13, Color.magenta);
        //				Debug.DrawLine(closestSurface1_14, closestSurface_14, Color.magenta);
        //				Debug.DrawLine(closestSurface1_15, closestSurface_15, Color.magenta);
        //				Debug.DrawLine(closestSurface1_16, closestSurface_16, Color.magenta);
        //				Debug.DrawLine(closestSurface1_17, closestSurface_17, Color.magenta);
        //				Debug.DrawLine(closestSurface1_18, closestSurface_18, Color.magenta);
        //
    }

	// Function to write the text into a *.txt file
	void WriteFile(){

//		// This text is added only once to the file
//		if (!System.IO.File.Exists("C:/Users/Ricardo/Downloads/MyTest.txt")){
//			//Create a file to write to.
//			string createText = "Hello and Welcome:";
//			System.IO.File.WriteAllText("C:/Users/Ricardo/Downloads/MyTest.txt", createText);
//		}

		//This text is always added, making the file longer over time if not deleted
		string appendText = dp + ", " + System.DateTime.Now.ToString()+", " + objectcolor + "\r\n";
		//System.IO.File.AppendAllText("C:/Users/DarkB/Downloads/MyTest.txt", appendText);

	}
    IEnumerator FlashRed()
    {
        Color defaultColor = Color.Lerp(redImage.color, Color.clear, flashSpeed * Time.deltaTime);
       
            // if the current color is the default color - change it to the flash color
            if (redImage.color == defaultColor)
            {
                redImage.color = flashColor;
            }
            else // otherwise change it back to the default color
            {
                redImage.color = defaultColor;
            }
            yield return new WaitForSeconds(flashSpeed);
        
       // yield return new WaitForSeconds(1F);
    }
}
