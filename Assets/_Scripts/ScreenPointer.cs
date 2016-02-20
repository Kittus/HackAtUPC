using UnityEngine;
using System.Collections;

public class ScreenPointer : MonoBehaviour {

    public Camera troll;
    public GameObject collision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("HOLA");
        RaycastHit hit;
        Ray ray = troll.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 10));
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			int layerMaskVR = 1 << LayerMask.NameToLayer ("VRButton");
			if (Physics.Raycast (ray, out hit, 700f, layerMaskVR)) {
				Debug.Log (hit.collider.gameObject.name);
			}
		}
        int layerMask = 1 << LayerMask.NameToLayer("Screen"); // only check for collisions with layerX
        if (Physics.Raycast(ray,out hit, 700f, layerMask))
        {
            collision.GetComponent<Renderer>().enabled = true;
            collision.transform.position = hit.point + new Vector3(0,0,collision.transform.position.z-hit.point.z);
        }
        else
            collision.GetComponent<Renderer>().enabled = false;
    }
}
