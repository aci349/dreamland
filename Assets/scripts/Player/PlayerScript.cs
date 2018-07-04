using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private float movementSpeed;                //vertical Player movement speed
	[SerializeField]
	private float movementForce;                //force that is added when the player presses one of the general movement keys (w,a,s,d)
    [SerializeField]
    private float jumpForce;                //force that is added when the player presses one of the general movement keys (w,a,s,d)

    [SerializeField]
	private float cameraSpeed;                //determines how fast the camera rotates

	private Rigidbody entityRB;               //reference to the player's Rigidbody
	private Transform groundCheck;              //reference to the ground check's transform

    [SerializeField]
    private bool grounded;                      //bool to check if the player is on viable ground
    [SerializeField]
    private bool floating;
    
    void Start()
	{
		entityRB = GetComponent<Rigidbody>();                 //initialize player Rigidbody
		groundCheck = transform.Find("playerGroundCheck");      //initialize groundCheck Transform
	}
	
	void Update ()
	{
        if (grounded)
		{
            if (floating)
            {
                if (Input.GetKey("space"))
                    entityRB.AddForce(transform.up * movementForce);
                if (Input.GetKey("left shift"))
                    entityRB.AddForce(-transform.up * movementForce);

                if (Mathf.Abs(entityRB.velocity.y) > movementSpeed)
                    entityRB.velocity = new Vector3(entityRB.velocity.x, Mathf.Sign(entityRB.velocity.y), entityRB.velocity.z * movementSpeed);
            }
            else
            {
                if (Input.GetKey("space"))
                    Jump();
            }

            if (Input.GetKey("a"))
			{
				entityRB.AddForce(-transform.right * movementForce);
			}
			else if (Input.GetKey("d"))
			{
				entityRB.AddForce(transform.right * movementForce);
			}

			if (Input.GetKey("w"))
			{
				entityRB.AddForce(transform.forward * movementForce);
			}
			else if (Input.GetKey("s"))
			{
				entityRB.AddForce(-transform.forward * movementForce);
			}

			if (Mathf.Abs(entityRB.velocity.x) > movementSpeed)
				entityRB.velocity = new Vector3(Mathf.Sign(entityRB.velocity.x) * movementSpeed, entityRB.velocity.y, entityRB.velocity.z);
            if (Mathf.Abs(entityRB.velocity.z) > movementSpeed)
				entityRB.velocity = new Vector3(entityRB.velocity.x, entityRB.velocity.y, Mathf.Sign(entityRB.velocity.z) * movementSpeed);

            if (Input.GetKeyUp("a") || Input.GetKey("d"))
                entityRB.velocity = new Vector3(entityRB.velocity.x, entityRB.velocity.y, 0);
            if (Input.GetKeyUp("w") || Input.GetKey("s"))
                entityRB.velocity = new Vector3(0, entityRB.velocity.y, entityRB.velocity.z);
        }

		float h = cameraSpeed * Input.GetAxis("Mouse X");
		float v = -cameraSpeed * Input.GetAxis("Mouse Y");

		Camera.main.transform.Rotate(v, 0, 0);
		transform.Rotate(0, h, 0);
	}

    void Jump()
    {
        entityRB.AddForce(transform.up * jumpForce);
    }

    public Rigidbody GetRigidbody()
    {
        return entityRB;
    }

    public void EnterFloating()
    {
        movementSpeed = movementSpeed / 2;

        entityRB.useGravity = false;
        entityRB.velocity = new Vector3(entityRB.velocity.x, 0, entityRB.velocity.z);
        floating = true;
        grounded = true;
    }

    public void ExitFloating()
    {
        movementSpeed = movementSpeed * 2;

        entityRB.useGravity = true;
        floating = false;
        grounded = false;
    }

    public void ToggleGrounded()
    {
        grounded = !grounded;
    }
}
