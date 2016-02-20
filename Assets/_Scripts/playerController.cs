using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float height = 2.0f;
    public float sensibility = 2.0f;
    public float speed = 3.0f;
	// Use this for initialization
	void Start () {
        transform.Translate(0f, height, 0f);
        Cursor.visible = false;
    }

    // Update is called once per frame
    /*void FixedUpdate () {
        float h = Input.GetAxis("Mouse X") * Time.deltaTime * sensibility*20;
        float v = Input.GetAxis("Mouse Y") * Time.deltaTime * sensibility*20;
       
       transform.Rotate (new Vector3(-v, h,0));
   
	}*/
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private bool timePass = false;

    void Update()
    {
        if (timePass) Time.timeScale = 1;
        else Time.timeScale = 0.05f;

        yaw += sensibility * Input.GetAxis("Mouse X");
        pitch -= sensibility * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void FixedUpdate()
    {
        timePass = false;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward* Time.deltaTime * speed);
            timePass = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            timePass = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            timePass = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            timePass = true;
        }

    }
}
