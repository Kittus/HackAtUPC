using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float height = 2.0f;
    public float sensibility = 2.0f;
    public float speed = 10.0f;
    public float timeScaleWhenStop = 0.05f;
    public float timeScaleMusic = 0.1f;
    public GameObject Parent;

    private AudioSource audio;
	// Use this for initialization
	void Start () {
        Parent.transform.Translate(0f, height, 0f);
        Cursor.visible = false;
        audio = GetComponent<AudioSource>();
    }
    
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    
    void Update()
    {
        yaw += sensibility * Input.GetAxis("Mouse X");
        pitch -= sensibility * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }


    //private float walkingIndex = 0f; //extra "y" for walking animation
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space)) Time.timeScale = 1;
        else if (h == 0 && v == 0) Time.timeScale = timeScaleWhenStop;
        else Time.timeScale = Mathf.Max(Mathf.Abs(h), Mathf.Abs(v));

        Vector3 v1 = transform.forward*v;
        v1 = transform.right*h + v1;
       
        v1.y = 0f;
        v1.Normalize();
        Parent.transform.position += v1*speed * Time.deltaTime;
       
        if (Time.timeScale < 1) audio.pitch = timeScaleMusic;
        else audio.pitch = 1;
    }
}
