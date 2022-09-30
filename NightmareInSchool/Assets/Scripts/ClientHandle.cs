﻿using UnityEngine;
using System.Net;
using System;

namespace Assets.Scripts
{
    public class ClientHandle : MonoBehaviour
    {
        // Start is called before the first frame update
        public static void Welcome(Packet _packet)
        {
            string _msg = _packet.ReadString();
            int _myId = _packet.ReadInt();

            Debug.Log($"Server Mesajı :{_msg}");
            Client.instance.myId = _myId;
            ClientSend.WelcomeReceived();

            Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);

        }




        public static void SpawnPlayer(Packet _packet)
        {
            int _id = _packet.ReadInt();
            string _username = _packet.ReadString();
            Vector3 _position = _packet.ReadVector3();
            Quaternion _rotation = _packet.ReadQuaternion();

            GameManager.instance.SpawnPlayer(_id, _username, _position, _rotation);
        }

        public static void PlayerPosition(Packet _packet)
        {
            int _id = _packet.ReadInt();
            Vector3 _position = _packet.ReadVector3();

            GameManager.players[_id].transform.position = _position;
        }

        public static void PlayerRotation(Packet _packet)
        {
            int _id = _packet.ReadInt();
            Quaternion _rotation = _packet.ReadQuaternion();

            GameManager.players[_id].transform.rotation = _rotation;
        }

        public static void ChatSystem(Packet _packet)
        {
             string message = _packet.ReadString();
            Debug.Log("Chat geldi"+message);

            GameManager.instance.SetText(message);
        }



    }
}
