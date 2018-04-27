using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
	public GameObject wind;
	public GameObject slider;
	public GameObject start;
	public GameObject startA;

	public GameObject options;
	public Slider windSlider;
	public static float windValue;


	// Use this for initialization
	void Start () {
		windSlider.onValueChanged.AddListener(delegate {ValueChangeCheck(); });
		wind.SetActive (false);
		slider.SetActive (false);
		startA.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			SceneManager.LoadScene ("Def Scene");
		}
		if (Input.GetButtonDown ("Fire3")) {
			Debug.Log ("Options");
			wind.SetActive (true);
			slider.SetActive (true);
			start.SetActive (false);
			startA.SetActive (true);

			options.SetActive (false);

		
		}
		if (Mathf.Abs (Input.GetAxis ("Horizontal_Right")) > 0.2f) {
			windSlider.value = Mathf.Abs (Input.GetAxis("Horizontal_Right"));
			windValue = windSlider.value;
		}
	}
	public void ValueChangeCheck()
	{
		Debug.Log(windSlider.value);
	}
}
