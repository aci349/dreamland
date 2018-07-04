using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentosCheck : MonoBehaviour {

    public mentos mentos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mentos")
        {
            foreach(GameObject go in mentos.allementos)
            {
                if(other == go)
                {
                    go.transform.Rotate(360, 0, 0);
                    if(go == mentos.mentoone)
                    {
                        mentos.mentoonehit = true;
                    } else if (go == mentos.mentotwo)
                    {
                        mentos.mentotwohit = true;
                    } else
                    {
                        mentos.mentothreehit = true;
                    }
                }
            }
        }
    }

}
