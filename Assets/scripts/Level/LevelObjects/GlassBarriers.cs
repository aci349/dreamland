using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBarriers : MonoBehaviour {

	private GameObject invisWall;

	private bool active;
	
	void Start ()
	{
		invisWall = GameObject.Find("Invis_Wall");

		active = false;
	}
	
	void Update ()
	{
		if (active)
		{
			transform.Translate(0, -Time.deltaTime * 2, 0);
		}
	}

	public void Activate()
	{
		active = true;
		Destroy(invisWall);
	}
}
