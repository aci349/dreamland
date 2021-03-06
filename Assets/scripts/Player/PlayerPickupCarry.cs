﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupCarry : MonoBehaviour {
	GameObject mainCamera; 
	bool carrying;	
	GameObject carriedObject; 
	public float bonbonThrowingForce = 5f;
	private GameObject spawner;
	private GameObject ritual;


	// Use this for initialization
	void Start () {
		spawner = GameObject.Find("BonbonSpawner");
		ritual = GameObject.Find("Ritual");
		mainCamera = GameObject.FindWithTag("MainCamera");
		/*if (carriedObject)
			carriedObject.GetComponent<Rigidbody>().useGravity = false;*/
	}
	
	// Update is called once per frame 
	//es wird überprüft ob bereits ein Objekt getragen wird 
	void Update () {
		if(carrying){
			carry(carriedObject);
			checkDrop();
		}
		else{
			pickup();
		}
	}
	
	//Objekt wird aufgehoben und bei Bewegung mittig unten vor Kamera mitgeführt
	void carry(GameObject o){
		//o.GetComponent<Rigidbody>().isKinematic = true;
		o.transform.position = mainCamera.transform.position + mainCamera.transform.forward * o.GetComponent<PickupCarryCube>().distance + -mainCamera.transform.up * 0.3f;  
	}
	
	//Objekt wird aufgehoben und verkleinert 
	void pickup(){
		if(Input.GetKeyDown(KeyCode.E)){ 
				Debug.Log("TestPickup");
				int x = Screen.width / 2;
				int y = Screen.height / 2;
				
				Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
				RaycastHit hit;
			
				if(Physics.Raycast(ray, out hit)){
					PickupCarryCube p = hit.collider.GetComponent<PickupCarryCube>();
					if(p != null){
						carrying = true;
						carriedObject = p.gameObject;
						p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
						p.gameObject.GetComponent<BoxCollider>().enabled = false;
						p.transform.localScale = p.transform.localScale / 3;
					}
				}
		}
	}
	
	//hier wird überprüft welches Objekt geworfen oder geschluckt werden kann und jeweils die zugehörige Funktion ausgeführt 
	void checkDrop(){
		if(Input.GetKeyDown(KeyCode.E)){
			if(carriedObject.tag == "werfen"){
				Debug.Log("TestWerfen");
				werfen();
			}
			else if(carriedObject.tag == "schlucken"){
				Debug.Log("TestSchlucken");
				schlucken();
			}
			else if (carriedObject.tag == "powder")
			{
				if (!carriedObject.GetComponent<Powder>().checkUse())
				{
					carriedObject.GetComponent<Powder>().StartUse();
				}
				else
				{
					carriedObject.GetComponent<Powder>().Terminate();
				}
			}
			else
			dropObject();
		}
	}
	
	void werfen(){
		//carrying = carryingBonbon;
		//carryingBonbon = false;
		//carrying = holdingBall;
		//holdingBall = false;
		dropObject();
		carriedObject.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * bonbonThrowingForce);
		carriedObject = null;
		spawner.GetComponent<ProjectileSpawner>().ReduceCount();
	}
	
	void schlucken(){
		//carrying = false;
		//carriedObject = null;
		dropObject();
		Destroy(carriedObject);
		carriedObject = null;
		ritual.GetComponent<Ritual>().InitiateRitual();
	}
	
	//loslassen; Objekt wird wieder vergrößert 
	void dropObject(){
		carrying = false;
		carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject.gameObject.GetComponent<BoxCollider>().enabled = true;
		carriedObject.transform.localScale = carriedObject.transform.localScale * 3;
		
		if (carriedObject.tag != "werfen" && carriedObject.tag != "schlucken")
		carriedObject = null;
	}
}
