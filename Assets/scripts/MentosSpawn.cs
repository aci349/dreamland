using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentosSpawn : MonoBehaviour {
    
    public GameObject einMentos;
    public int cntMentos;
    public float timer;
    private float spawntimer = 3f;

    // Use this for initialization
    void Start () {

        timer = 0;
        cntMentos = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        if (timer >= spawntimer)
        {
            if (cntMentos < 3)
            {
                Instantiate(einMentos);
                cntMentos++;

                timer = 0;
            }
        }
    }

    public void ChangeCnt ()
    {
        cntMentos--;
    }
}
