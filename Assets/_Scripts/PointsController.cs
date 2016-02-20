using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {
	private int count;
	public Text countText;
	private float dtime;
	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();		
		dtime = Time.time;


	}
	
	// Update is called once per frame
	void Update () {
		count = (int) (Time.time - dtime);
		SetCountText ();
		
	}
	void SetCountText ()
	{
		countText.text = "Points: " + count.ToString ();
	
	}
}
