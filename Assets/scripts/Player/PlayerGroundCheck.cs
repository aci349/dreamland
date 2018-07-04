using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour {

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ground")
        {
            transform.parent.GetComponent<PlayerScript>().ToggleGrounded();
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            transform.parent.GetComponent<PlayerScript>().ToggleGrounded();
        }
    }
}
