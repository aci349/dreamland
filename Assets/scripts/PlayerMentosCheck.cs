using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMentosCheck : MonoBehaviour
{
    public GameObject spawner;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "mentos")
        {
            other.GetComponent<Mentos>().MentosHit();

            spawner.GetComponent<MentosSpawn>().ChangeCnt();
        }
    }

}
