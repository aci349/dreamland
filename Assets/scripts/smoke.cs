using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoke : MonoBehaviour {

	private GameObject joint;
	private GameObject smokeSphere;
	
	public float timeStart = 0f;
	public float timeStop;
	public float sphereSize = 0.2f;
	public bool stop;
	
	// Use this for initialization
	void Start () {
		joint = GameObject.Find("Cylinder");
		smokeSphere = GameObject.Find("Sphere");
		joint.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		smokeSphere.gameObject.GetComponent<Rigidbody>().isKinematic = true;
		
		smokeSphere.transform.position = joint.transform.position;
		timeStop = Random.Range(5f, 13f);	
	} 
	
	// Update is called once per frame
	void Update () {
		producesmoke();
		if(stop == true){
			Debug.Log("TestObSmokeSphereNullIst");
			timeStart = 0f;
			producesmoke();
		}
	}                                   
	
	void producesmoke(){
		Debug.Log("TestTimerStart");
		if(timeStart < timeStop){	
			timeStart += Time.deltaTime;
			stop = false;
			smokeSphere.transform.Translate(Vector3.up * Time.deltaTime * Random.Range(0.5f, 3f), Space.World);	//Rauch/Spehre steigt nach oben
			Debug.Log("TestSphereVergrößern");
			smokeSphere.transform.localScale += new Vector3(Random.Range(0.005f, 0.03f), Random.Range(0.005f, 0.03f), Random.Range(0.005f, 0.03f));	//Rauch/Sphere wird größer
		}
		else{
			Debug.Log("TestTimerStop");
			stop = true;
			smokeSphere.transform.position = joint.transform.position;
			smokeSphere.transform.localScale = new Vector3(sphereSize, sphereSize, sphereSize);
		}
	}
	
}
