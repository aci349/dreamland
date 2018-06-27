using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour {

    private Rigidbody playerRB;

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if(!playerRB)
                playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().EntityRB;

            playerRB.useGravity = false;
            playerRB.velocity = new Vector3(playerRB.velocity.x, 0, playerRB.velocity.z);
            col.GetComponent<PlayerScript>().Floating = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            playerRB.useGravity = true;
            col.GetComponent<PlayerScript>().Floating = false;
        }
    }
}
