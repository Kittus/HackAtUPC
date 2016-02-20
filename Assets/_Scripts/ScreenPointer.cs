﻿using UnityEngine;
using System.Collections;

public class ScreenPointer : MonoBehaviour {

    public Camera troll;
    public GameObject collision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        Ray ray = troll.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 10));
		if (Input.GetKeyDown (KeyCode.JoystickButton2)) {	
			int layerMaskVR = 1 << LayerMask.NameToLayer ("VRButton");
			if (Physics.Raycast (ray, out hit, 700f, layerMaskVR)) {
				Debug.Log (hit.collider.gameObject.name);
				if (hit.collider.gameObject.name =="Rock It"){
					LoadOnClick.LoadScene(1);
				}
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
