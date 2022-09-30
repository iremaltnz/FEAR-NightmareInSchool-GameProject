using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassScript : MonoBehaviour
{
    // Start is called before the first frame update

    //public Transform teleportTarget;
    public GameObject player;

    public float xPosition;
    public float yPosition;
    public float zPosition;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggerİçi");
         //   player.transform.position = teleportTarget.transform.position;

            player.transform.position = new Vector3(xPosition, yPosition,zPosition);

            ClientSend.PlayerPosition(player.transform);

 
        }

    }
}
