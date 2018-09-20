using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mentos : MonoBehaviour {
    private float speed = 0.02f;
    private float directiontimer = 2f;
    public float timer;

    public bool mentoonehit = false;

    // Use this for initialization
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Run();

        timer += Time.deltaTime;
        if (timer >= directiontimer)
        {
            Turn();
            timer = 0;
        }

    }

    private void Run()
    {
        if (mentoonehit == false)
        {
            transform.Translate(0f, 0f, speed);
        }
    }

    private void Turn()
    {
        if (mentoonehit == false)
        {
            transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }

    public void MentosHit()
    {
        transform.Rotate(0, 0, 90);
        mentoonehit = true;
		this.gameObject.AddComponent<PickupCarryCube>();
		GetComponent<PickupCarryCube>().distance = 0.5f;
		transform.Rotate(90, 0, 0);
    }
}
