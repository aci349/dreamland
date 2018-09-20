using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class LastDoorScript : MonoBehaviour {
	
	public bool isTriggered;
    public int door1;
	
	//tür wartet bis die Zielscheibe 3 mal getroffen wir
    public void Door ()

    {
        door1++;

        if (door1 == 3)
            OpenDoor();
    }

	//tür ist weg
 void OpenDoor()
 
    {
        Destroy(this.gameObject);

    }
}
