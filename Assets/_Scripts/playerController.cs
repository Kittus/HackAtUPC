using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float height = 2.0f;
    public float sensibility = 2.0f;
    public float speed = 6.0f;

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
            Vector3 v = transform.forward;
            v.y = 0f;
            v.Normalize();
            transform.position += v;
            timePass = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 v = transform.forward;
            v.y = 0f;
            v.Normalize();
            transform.position -= v;
            timePass = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 v = transform.right;
            v.y = 0f;
            v.Normalize();
            transform.position += v;
            timePass = true;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 v = transform.right;
            v.y = 0f;
            v.Normalize();
            transform.position -= v;
            timePass = true;
        }

    }
}
