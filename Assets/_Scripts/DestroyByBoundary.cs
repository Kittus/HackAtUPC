using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Fallen") {
			Destroy (other.gameObject);
		}
	}
}
