using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour {
	
	public bool isTriggered;

	//durch ein box collider wird das werfen präziser
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "werfen")
		{	
			 Destroy(other.gameObject);
			 isTriggered = true;
            GameObject.Find("Room1_Gate").GetComponent<LastDoorScript>().Door();

			Destroy(this.gameObject);
			
        
		}
	}
	//die tür offnet sich
	//bonbon ist dann weg
	
	void Update () {
		
		}
		
}

		
		