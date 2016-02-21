using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Fallen") {
			Destroy (other.gameObject);
		} else if (other.CompareTag ("Player")) {
			Debug.Log ("destroyByBoundary");
			other.gameObject.GetComponent<PlayerHealth> ().Death ();
		}
	}
}
