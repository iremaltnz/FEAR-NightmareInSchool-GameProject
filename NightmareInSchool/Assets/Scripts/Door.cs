using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject door;

    public AudioSource sound;

    public void OnTriggerStay(Collider col)
    {

        if (col.tag == "Player")
        {
            if (Input.GetKey("e"))
            {
                sound.Play();
                Quaternion rot = Quaternion.Euler(0, 0, 45);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, rot, 1);
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
