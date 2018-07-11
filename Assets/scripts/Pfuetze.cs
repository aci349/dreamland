using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfuetze : MonoBehaviour {

    private bool mentoshit;
    private float platformtimerup = 3f;
    public float timer;
    public GameObject einBubble;

    //ontriggerenter 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "mentos")
        {
            mentoshit = true;
            Bubbles();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && mentoshit == true)
        {
            if (timer >= platformtimerup)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1500f, 0f));
                timer = 0;
                mentoshit = false;
            }
        }
    }

    private void Bubbles()
    {
        for (int i = 0; i < 11; i++)
        {
            Instantiate(einBubble);
        }
    }

    // Use this for initialization
    void Start () {
        timer = 0;
        mentoshit = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (mentoshit == true)
        {
            timer += Time.deltaTime;
        }
    }
}
