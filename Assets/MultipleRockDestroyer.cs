using UnityEngine;
using System.Collections;

public class MultipleRockDestroyer : MonoBehaviour {

	private float time;

	// Use this for initialization
	void Awake () {
		time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time-time)>1.0f) GetComponentInChildren <MeshRenderer> ().enabled=true;
	}

	void OnCollisionExit (Collision other){
		if (other.gameObject.name.Contains("Hazard") && (Time.time-time)<0.5f) {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
	}
}
