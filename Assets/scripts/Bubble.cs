using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {

    public GameObject spawnrange;
    float currsize;
    float maxsize;
    bool downsize;

	// Use this for initialization
	void Start () {
        downsize = false;
        currsize = 0.01f;
        maxsize = 1.1f;

        spawnrange = GameObject.Find("Pfuetze");

        float posx = Random.Range(-1.5f, 1.5f);
        float posz = Random.Range(-1.5f, 1.5f);
        transform.position = new Vector3(spawnrange.transform.position.x + posx, spawnrange.transform.position.y, spawnrange.transform.position.z + posz);
	}
	
	// Update is called once per frame
	void Update () {
        if (downsize == false)
        {
            currsize += 0.02f;
            transform.localScale = new Vector3(currsize, currsize, currsize);
            if (currsize >= maxsize)
            {
                downsize = true;
            }
        } else
        {
            currsize -= currsize;
            transform.localScale = new Vector3(currsize, currsize, currsize);
            if (currsize <= 0.01f)
            {
                float posx = Random.Range(-1.5f, 1.5f);
                float posz = Random.Range(-1.5f, 1.5f);
                transform.position = new Vector3(spawnrange.transform.position.x + posx, spawnrange.transform.position.y, spawnrange.transform.position.z + posz);
                downsize = false;
            }
        }
	}
}
