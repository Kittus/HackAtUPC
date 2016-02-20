using UnityEngine;
using System.Collections;

public class Debugging : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.JoystickButton4)) Debug.Log (4);
		if (Input.GetKeyDown(KeyCode.JoystickButton5)) Debug.Log (5);

	}
}
