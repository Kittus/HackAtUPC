using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMenuController : MonoBehaviour {

    GameObject gameOverTxt;

    // Use this for initialization
    void Start () {
        gameOverTxt = GameObject.FindGameObjectWithTag("GameOverTxt");
        gameOverTxt.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void setGameOverUI()
    {
        gameOverTxt.SetActive(true);

        // Wait for X too be pressed
        if (Input.GetKeyDown(KeyCode.Joystick1Button2)){
            LoadOnClick.LoadScene(0);
        }
    }
}
