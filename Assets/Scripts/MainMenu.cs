using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene("Def Scene");
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Options");
                }
    }
}
