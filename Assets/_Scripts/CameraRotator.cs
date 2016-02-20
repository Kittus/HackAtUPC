using UnityEngine;
using System.Collections;

public class CameraRotator : MonoBehaviour {
	public float speed;
	public void Update (){
		transform.Rotate (0, Input.GetAxisRaw ("Custom") * speed * Time.deltaTime, 0);
	}
}
