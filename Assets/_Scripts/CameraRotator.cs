using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {
	public float speed;
	public void Update (){
		if (Input.GetKey(KeyCode.JoystickButton4)) transform.Rotate (0, speed * Time.unscaledDeltaTime, 0);
		if (Input.GetKey(KeyCode.JoystickButton5)) transform.Rotate (0, -speed * Time.unscaledDeltaTime, 0);
	}
}
