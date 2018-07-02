using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private float movementSpeed;                //vertical Player movement speed
	[SerializeField]
	private float movementForce;                //force that is added when the player presses one of the general movement keys (w,a,s,d)

	[SerializeField]
	private float cameraSpeed;                //determines how fast the camera rotates

	private Rigidbody entityRB;               //reference to the player's Rigidbody
	private Transform groundCheck;              //reference to the ground check's transform

	private bool grounded;                      //bool to check if the player is on viable ground

	public bool Grounded
	{
		get
		{
			return grounded;
		}
		set
		{
			grounded = value;
		}
	}	

	void Start()
	{
		entityRB = GetComponent<Rigidbody>();                 //initialize player Rigidbody
		groundCheck = transform.Find("playerGroundCheck");      //initialize groundCheck Transform

		grounded = true;
	}
	
	void Update ()
	{
		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		if (grounded)
		{
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

		}

		float h = cameraSpeed * Input.GetAxis("Mouse X");
		float v = -cameraSpeed * Input.GetAxis("Mouse Y");

		Camera.main.transform.Rotate(v, 0, 0);
		transform.Rotate(0, h, 0);
	}
}
