using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mentos : MonoBehaviour {
    private float speed = 0.01f;
    private float directiontimer = 2f;
    public float timer;
    public int tic;

    GameObject mento;

	// Use this for initialization
	void Start () {
        mento = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mento.transform.localScale -= new Vector3(0.8f, 0.5f, 0.5f);
        mento.transform.position -= new Vector3(0f, 1.1f, 0f);

        timer = 0;

}
	
	// Update is called once per frame
	void Update () {

        //if collided
        mento.transform.Translate(0f, 0f, speed);

        timer += Time.deltaTime;
        if (timer >= directiontimer)
        {
            Run();
            timer = 0;
        }

    }

    private void Run()
    {
        mento.transform.Rotate(0, Random.Range(0, 360), 0);
    }
}
