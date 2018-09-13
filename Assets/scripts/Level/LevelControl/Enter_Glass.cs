using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter_Glass : MonoBehaviour {

	private GameObject barriers;

	void Start()
	{
		barriers = GameObject.Find("GlassBarriers");
	}

	private void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
		}
	}
}
