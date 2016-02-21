using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image Fill;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float damageDivisor = 20.0f;

  

    public bool isDead;
    bool damaged;

    // Use this for initialization
    void Start () {
        currentHealth = startingHealth;
        isDead = false;
    }
	

    void Update()
    {
        Fill.color = Color.Lerp(Color.red, Color.green, (float)currentHealth / startingHealth);

        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }


    public void TakeDamage(int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;


        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    public void Death()
    { 
		if (!isDead) {
			Debug.Log ("Death()");
			isDead = true;
			int finalScore = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PointsController> ().count;
			PlayerPrefs.SetInt ("Last Score", finalScore);
			int highScore = PlayerPrefs.GetInt ("High Score");


			if (finalScore > highScore) { //when player dies set highscore = to that score
				highScore = finalScore;
				PlayerPrefs.SetInt ("High Score", highScore);
			}

            GameObject.Find("CameraContainer").GetComponent<PointsController>().StopCounting();

			GameObject canvas = GameObject.FindGameObjectWithTag ("Canvas");
            canvas.GetComponent<GameMenuController>().setGameOverUI();
		}
    }


    void OnCollisionEnter(Collision col)
    {
            if (col.collider.CompareTag("Fallen"))
            {
                TakeDamage((int)((col.collider.GetComponent<Rigidbody>().mass) / damageDivisor));
            }        
    }
}
