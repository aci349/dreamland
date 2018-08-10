using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour {

    private GameObject player;
    private bool tracking;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tracking = true;
    }


    void Update()
    {
        if (tracking)
        {
            Vector3 target = player.transform.position;

            transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.01f);

        }

    }
}
