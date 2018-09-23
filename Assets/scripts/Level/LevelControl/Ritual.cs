using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ritual : MonoBehaviour {

	private GameObject room2_hidden;            //reference to the initially hidden objects
	private GameObject room2_initial;           //reference to the initially visible objects that are hidden when the ritual starts

	private GameObject summon;					//reference to the Alarm Clock

	//references to the five candles in the ritual room
	private GameObject[] candles = new GameObject[5];

	private Powder powder;					//reference to the powder GameObject

	private int stage;                      //internal stage of the ritual
	private int nextStage;                      //next requiered stage of the ritual
	private bool finish;						//check if the ritual can be completed
	private bool complete;						//check if ritual is completed

	void Start ()
	{
		room2_hidden = GameObject.Find("Room2_hidden");
		room2_initial = GameObject.Find("Room2_initial");

		summon = GameObject.Find("Wecker");

		candles[0] = GameObject.Find("Candle1");
		candles[1] = GameObject.Find("Candle2");
		candles[2] = GameObject.Find("Candle3");
		candles[3] = GameObject.Find("Candle4");
		candles[4] = GameObject.Find("Candle5");

		powder = GameObject.Find("SackOfPowder").GetComponent<Powder>();

		room2_hidden.SetActive(false);

		finish = false;
		complete = false;
	}
	
	void Update ()
	{
		if (Input.GetKey("u"))
		{
			CompleteRitual();
		}

		if (complete)
		{
			Debug.Log(summon.transform.position.y);
			summon.transform.Rotate(new Vector3(0, Time.deltaTime * 4, 0));
			if (summon.transform.position.y < -7)
				summon.transform.Translate(new Vector3(0, Time.deltaTime * 2, 0));
		}
	}

	public void SetStage(int n)
	{
		if (n == 1 && finish)
		{
			CompleteRitual();
		}
		else
		{
			if (n == nextStage)
			{
				stage = n;

				if (n == 5)
				{
					nextStage = 1;
					finish = true;
					candles[n - 1].GetComponent<Candles>().LightControl(false);
					candles[0].GetComponent<Candles>().LightControl(true);
				}
				else
				{
					nextStage = n + 1;
					candles[n - 1].GetComponent<Candles>().LightControl(false);
					candles[n].GetComponent<Candles>().LightControl(true);
				}
			}
			else
				ResetRitual();
		}
	}

	//reset the ritual to stage 1 and reset the lights
	void ResetRitual()
	{
		stage = 0;
		nextStage = 1;
		candles[0].GetComponent<Candles>().LightControl(true);
		candles[1].GetComponent<Candles>().LightControl(false);
		candles[2].GetComponent<Candles>().LightControl(false);
		candles[3].GetComponent<Candles>().LightControl(false);
		candles[4].GetComponent<Candles>().LightControl(false);
	}

	public void InitiateRitual()
	{
		Destroy(GameObject.Find("DefaultLight_RitualRoom"));
		room2_hidden.SetActive(true);
		room2_initial.SetActive(false);

		stage = 0;
		nextStage = 1;
		candles[0].GetComponent<Candles>().LightControl(true);
	}

	void CompleteRitual()
	{
		candles[0].GetComponent<Candles>().LightControl(true);
		candles[1].GetComponent<Candles>().LightControl(true);
		candles[2].GetComponent<Candles>().LightControl(true);
		candles[3].GetComponent<Candles>().LightControl(true);
		candles[4].GetComponent<Candles>().LightControl(true);

		powder.EndUse();

		complete = true;			//signal the ritual to be complete
	}
}
