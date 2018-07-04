using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mentos : MonoBehaviour {
    private float speed = 0.01f;
    private float directiontimer = 2f;
    public float timer;
    public int tic;

    public bool mentoonehit = false;
    public bool mentotwohit = false;
    public bool mentothreehit = false;

    public GameObject mentoone;
    public GameObject mentotwo;
    public GameObject mentothree;

    public List<GameObject> allementos;

	// Use this for initialization
	void Start () {
        CreateMentos();

        timer = 0;
}
	
	// Update is called once per frame
	void Update () {

        Run();

        timer += Time.deltaTime;
        if (timer >= directiontimer)
        {
            Turn();
            timer = 0;
        }

    }


    private void CreateMentos()
    {
        mentoone = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mentoone.tag = "mento";
        mentoone.transform.localScale -= new Vector3(0.8f, 0.5f, 0.5f);
        mentoone.transform.position -= new Vector3(0f, 1.1f, 0f);

        SphereCollider one = (SphereCollider)mentoone.gameObject.AddComponent(typeof (SphereCollider));
        one.center = new Vector3(0.8f, 0.5f, 0.5f);

        mentotwo = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mentoone.tag = "mentos";
        mentotwo.transform.localScale -= new Vector3(0.8f, 0.5f, 0.5f);
        mentotwo.transform.position -= new Vector3(0f, 1.1f, 0f);

        SphereCollider two = (SphereCollider)mentotwo.gameObject.AddComponent(typeof(SphereCollider));
        two.center = new Vector3(0.8f, 0.5f, 0.5f);

        mentothree = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mentoone.tag = "mentos";
        mentothree.transform.localScale -= new Vector3(0.8f, 0.5f, 0.5f);
        mentothree.transform.position -= new Vector3(0f, 1.1f, 0f);

        SphereCollider three = (SphereCollider)mentothree.gameObject.AddComponent(typeof(SphereCollider));
        three.center = new Vector3(0.8f, 0.5f, 0.5f);

        List<GameObject> allementos = new List<GameObject>();
        allementos.Add(mentoone);
        allementos.Add(mentotwo);
        allementos.Add(mentothree);

    }

    private void Run()
    {
        if (mentoonehit == false)
        {
            mentoone.transform.Translate(0f, 0f, speed);
        }
        if (mentotwohit == false)
        {
            mentotwo.transform.Translate(0f, 0f, speed);
        }
        if (mentothreehit == false)
        {
            mentothree.transform.Translate(0f, 0f, speed);
        }
    }

    private void Turn()
    {
        if (mentoonehit == false)
        {
            mentoone.transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (mentotwohit == false)
        {
            mentotwo.transform.Rotate(0, Random.Range(0, 360), 0);
        }
        if (mentothreehit == false)
        {
            mentothree.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
}
