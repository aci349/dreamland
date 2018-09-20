using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pfuetze : MonoBehaviour {

	[SerializeField]
    private bool mentoshit;
    private float platformtimerup = 3f;
    public float timer;
    public GameObject einBubble;
	private Transform spawnposition;

    //ontriggerenter 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "mentos")
        {
			spawnposition = collision.gameObject.transform;
            mentoshit = true;
            Bubbles();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player" && mentoshit == true)
        {
            if (timer >= platformtimerup)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 1500f, 0f));
                timer = 0;
            }
        }
    }

    private void Bubbles()
    {
        for (int i = 0; i < 11; i++)
        {
            Instantiate(einBubble, spawnposition.position, spawnposition.rotation);
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
