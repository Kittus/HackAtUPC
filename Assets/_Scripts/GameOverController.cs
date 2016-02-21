using UnityEngine;
using System.Collections;

public class GameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("aa");
		if (Input.GetKeyDown(KeyCode.Joystick1Button2)){
			LoadOnClick.LoadScene(0);
		}
	}

	// Go to Main Menu
	void goToMainMenu(){

	}
}
