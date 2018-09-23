using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candles : MonoBehaviour {

	private Light candleLight;
	private GameObject powder;

	[SerializeField]
	private int number;

	void Start()
	{
		candleLight = GetComponentInChildren<Light>();
		powder = GameObject.Find("SackOfPowder");
		LightControl(false);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player" && powder.GetComponent<Powder>().checkUse())
		{
			GameObject.Find("Ritual").GetComponent<Ritual>().SetStage(number);
		}
	}

	//Turn light on or off
	public void LightControl(bool on)
	{
		if (on)
			candleLight.enabled = true;
		else
			candleLight.enabled = false;
	}
}
