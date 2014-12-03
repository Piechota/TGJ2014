using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {
    public float movementSpeed = 0.03f;
    public float rotationSpeed = 1.0f;
    public GameObject fppCamera;
    private float jumpForce = 3000.0f;
    public GroundCheckerScript groundCheck;
    private bool jumping = false;

	// Use this for initialization
	void Start () {
        Screen.showCursor = false;
	}

    void FixedUpdate()
    {
        Vector3 direction = Vector3.zero;

        direction += transform.forward * Input.GetAxisRaw("Vertical") * movementSpeed * Time.fixedDeltaTime;
        direction += transform.right * Input.GetAxisRaw("Horizontal") * movementSpeed * Time.fixedDeltaTime;

        if(Input.GetKey(KeyCode.Escape))
            Application.Quit();
        if (Input.GetKey(KeyCode.L))
            Application.LoadLevel(Application.loadedLevel);
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        Screen.showCursor = false;
        direction.Normalize();

        if (!audio.isPlaying && direction.magnitude > 0)
        {
            audio.Play();
        }
        else if (direction.magnitude == 0)
        {
            audio.Stop();
        }

        rigidbody.MovePosition(this.transform.position + direction * movementSpeed);
    }

	// Update is called once per frame
	void Update () {

        //Rotating
        transform.Rotate(Vector3.up, rotationSpeed * Input.GetAxis("RightHorizontal") * Time.deltaTime);
        fppCamera.transform.localEulerAngles = new Vector3(rotationSpeed * Input.GetAxis("RightVertical") * Time.deltaTime + fppCamera.transform.localEulerAngles.x, 0);

        //Jumping
        if (Input.GetButtonDown("Jump") && groundCheck.Grounded)
        {
            Jump();
            //Debug.Log("Jump performed");
        }

        if (jumping && Input.GetButtonUp("Jump"))
        {
            jumping = false;
        }
	}

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
        jumping = true;
    }
}
