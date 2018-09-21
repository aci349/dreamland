using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour {

	private GameObject joint;
	
	public float timeStart = 0f;
	public float timeStop;
	public float sphereSize = 0.2f;
	public bool stop;
	
	// Use this for initialization
	void Start () {
		joint = GameObject.Find("Cylinder");
		joint.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		
		transform.position = joint.transform.position;
		timeStop = Random.Range(1f, 4f);	
	} 
	
	// Update is called once per frame
	void Update () {
		producesmoke();
		if(stop == true){
			timeStart = 0f;
			producesmoke();
		}
	}                                   
	
	void producesmoke(){
		if(timeStart < timeStop){	
			timeStart += Time.deltaTime;
			stop = false;
			transform.Translate(Vector3.up * Time.deltaTime * Random.Range(0.5f, 3f), Space.World);	//Rauch steigt nach oben
			transform.localScale += new Vector3(Random.Range(0.005f, 0.03f), Random.Range(0.005f, 0.03f), Random.Range(0.005f, 0.03f));	//Rauch wird größer
		}
		else{
			stop = true;
			transform.position = joint.transform.position;	//Rauch wird zurück gesetzt
			transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
		}
	}
	
}
