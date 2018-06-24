using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

	private GameObject player;			//reference to the player gameobject

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		transform.position = player.transform.position;
		transform.rotation = player.transform.rotation;
	}
	
	void Update ()
	{
		float h = 3 * Input.GetAxis("Mouse X");
		float v = -3 * Input.GetAxis("Mouse Y");
		transform.Rotate(v, h, 0);

		transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
	}
}
