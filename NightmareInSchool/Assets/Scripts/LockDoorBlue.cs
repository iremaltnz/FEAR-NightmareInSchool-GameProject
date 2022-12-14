using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockDoorBlue : MonoBehaviour
{
    public GameObject door;

    public AudioSource sound;
    public Text blueKey;

    public void OnTriggerStay(Collider col)
    {
      

        if (Input.GetKey("e"))
        {
            if (col.tag == "Player")
            {
               
                if (door.tag == "DoorBlue")
                {
                   
                    if (blueKey.text == "Blue Key = 3")
                    {
                        sound.Play();
                        Quaternion rot = Quaternion.Euler(0, 0, 90);
                        transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, 1);

                      
                    }
                }
              
            }

        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, 1);
        }
    }
}

