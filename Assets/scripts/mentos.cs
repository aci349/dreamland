using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mentos : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject mentos = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mentos.transform.localScale -= new Vector3(0.5f, 0.8f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
