using UnityEngine;
using System.Collections;

public class RedDamage : MonoBehaviour {
	public Camera cam;
	public float dist;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = cam.transform.position + cam.transform.forward.normalized*dist;
		//this.transform.rotation = cam.transform.rotation;
		this.transform.LookAt (cam.transform.position, cam.transform.up);
	}
}
