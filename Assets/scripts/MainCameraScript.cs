using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour {

	private GameObject player;			//reference to the player gameobject

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");

		transform.position = player.transform.position + transform.up * 0.75f;
		transform.rotation = player.transform.rotation;
	}
	
	void Update ()
	{
	}
}
