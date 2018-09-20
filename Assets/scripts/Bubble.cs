using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	
    float currsize;
    float maxsize;
    bool downsize;

	// Use this for initialization
	void Start () {
        downsize = false;
        currsize = 0.01f;
        maxsize = 1.1f;

        float posx = Random.Range(-1.5f, 1.5f);
        float posz = Random.Range(-1.5f, 1.5f);
        transform.position = new Vector3(transform.position.x + posx, transform.position.y - 0.25f, transform.position.z + posz);
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
                transform.position = new Vector3(transform.position.x + posx, transform.position.y, transform.position.z + posz);
                downsize = false;
            }
        }
	}
}
