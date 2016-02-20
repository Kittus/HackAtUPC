using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float height = 2.0f;
    public float sensibility = 2.0f;
    public float speed = 6.0f;
    public float timeScaleWhenStop = 0.05f;

    public GameObject Parent;

	// Use this for initialization
	void Start () {
        Parent.transform.Translate(0f, height, 0f);
        Cursor.visible = false;
    }
    
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    
    void Update()
    {
        yaw += sensibility * Input.GetAxis("Mouse X");
        pitch -= sensibility * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }

    void FixedUpdate()
    {
        Time.timeScale = timeScaleWhenStop;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Time.timeScale = 1;
            Vector3 v = transform.forward;
            v.y = 0f;
            v.Normalize();
            Parent.transform.position += v;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Time.timeScale = 1;
            Vector3 v = transform.forward;
            v.y = 0f;
            v.Normalize();
            Parent.transform.position -= v;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Time.timeScale = 1;
            Vector3 v = transform.right;
            v.y = 0f;
            v.Normalize();
            Parent.transform.position += v;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Time.timeScale = 1;
            Vector3 v = transform.right;
            v.y = 0f;
            v.Normalize();
            Parent.transform.position -= v;
        }

    }
}
