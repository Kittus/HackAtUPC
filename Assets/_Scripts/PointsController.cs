using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsController : MonoBehaviour {
	public int count;
	public Text countText;
	private float dtime;
	private bool alive=true;
	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();		
		dtime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (alive) {
			count = (int)(Time.time - dtime);
			SetCountText ();
		}
		
	}
	void SetCountText ()
	{
		countText.text = "Points : " + count.ToString ();
	    
	}
	public void StopCounting (){
		alive = false;
	}
}
