using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : MonoBehaviour {

	[SerializeField]
	private float number;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Debug.Log("Activated Candle " + number);
		}
	}
}
