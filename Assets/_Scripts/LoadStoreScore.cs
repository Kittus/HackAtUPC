using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadStoreScore : MonoBehaviour {
	
	public Text high;
	public Text last;
	private int highScore=0;
	private int lastScore=0 ;
	// Use this for initialization
	void Start () {
		lastScore = PlayerPrefs.GetInt ("Last Score");
		highScore = PlayerPrefs.GetInt("High Score");
		high.text = highScore.ToString ();
		last.text = lastScore.ToString ();

	}

	void GameOver (int finalScore){
		PlayerPrefs.SetInt ("Last Score", finalScore);
		if(finalScore > highScore) //when player dies set highscore = to that score
		{
			highScore = finalScore;
			PlayerPrefs.SetInt("High Score", highScore);


		} 
	}
}
