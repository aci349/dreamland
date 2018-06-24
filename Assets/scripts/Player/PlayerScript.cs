using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	[SerializeField]
	private float movementSpeed;                //vertical Player movement speed

	private Rigidbody entityRB;               //reference to the player's Rigidbody
	private Transform groundCheck;              //reference to the ground check's transform

	private bool grounded;                      //bool to check if the player is on viable ground

	void Start()
	{
		entityRB = GetComponent<Rigidbody>();                 //initialize player Rigidbody
		groundCheck = transform.Find("playerGroundCheck");      //initialize groundCheck Transform
	}
	
	void Update ()
	{
		//grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

		//if (grounded)
		//{
		
		if (Input.GetKey("a"))
		{
			entityRB.velocity = new Vector3(movementSpeed * -1, entityRB.velocity.y, entityRB.velocity.z);
		}
		else if (Input.GetKey("d"))
		{
			entityRB.velocity = new Vector3(movementSpeed, entityRB.velocity.y, entityRB.velocity.z);
		}

		if (Input.GetKey("w"))
		{
			entityRB.velocity = new Vector3(entityRB.velocity.x, entityRB.velocity.y, movementSpeed);
		}
		else if (Input.GetKey("s"))
		{
			entityRB.velocity = new Vector3(entityRB.velocity.x, entityRB.velocity.y, movementSpeed * -1);
		}
	}
}
