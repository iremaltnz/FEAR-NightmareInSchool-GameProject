using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public InputField chatMessage;
  

    public void Send()
    {
        ClientSend.ChatSystem(Convert.ToString(chatMessage.text) , Client.instance.userName) ;
    }



}
