using UnityEngine;
using System.Collections;

public class DoorScripts : MonoBehaviour
{

    public static bool doorKey;
    public bool open;
    public bool close;
    public bool inTrigger;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "KeyTag")
        {
            OpenDoor();
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
   
       inTrigger = true;
    }

    void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

    void Update()
    {
        /*if (inTrigger)
        {
            if (close)
            {
                if (doorKey)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //open = true;
                        close = false;
                        OpenDoor();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    close = true;
                    //open = false;
                    CloseDoor();
                   

                }
            }
        }

        if (open)
         {
             Vector3 newPosition = transform.forward * 5; transform.position = newPosition;
             //var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(90.0f, -90.0f, 0.0f), Time.deltaTime * 200);
             //transform.rotation = newRot;
         }
         else
         {
             Vector3 newPosition = -transform.forward * 5; transform.position = newPosition;
             //var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(.0f, 0.0f, 0.0f), Time.deltaTime * 200);
             //transform.rotation = newRot;
         }
         */

    }


    void OpenDoor()
    {
        Vector3 newPosition = transform.position + transform.right *3; transform.position = newPosition;

    }

    void CloseDoor()
    {
        Vector3 newPosition = transform.position + -transform.right * 3; transform.position = newPosition;
    }


    void OnGUI()
    {
        if (inTrigger)
        {
            if (open)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press E to close");
            }
            else
            {
                if (doorKey)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Press E to open");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a key!");
                }
            }
        }
    }
}