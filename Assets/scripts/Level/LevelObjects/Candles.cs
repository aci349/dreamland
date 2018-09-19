using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : MonoBehaviour {

	private Light candleLight;

	[SerializeField]
	private float number;

	void Start()
	{
		candleLight = GetComponentInChildren<Light>();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Debug.Log("Activated Candle " + number);
		}
	}

	public void LightControl(bool on)
	{
		if (on)
			candleLight.enabled = true;
		else
			candleLight.enabled = false;
	}
}
