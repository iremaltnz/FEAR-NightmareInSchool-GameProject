using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BackgroundSound : MonoBehaviour
{

    public AudioSource source;

  
    public AudioClip helpUs;
    public AudioClip helpMe;

    float timer=0;
    float timer2 = 0;

    void Start()
    {
       
    }

  
    void Update()
    {
        if (timer > 10 && timer <20 && source.isPlaying==false)
        {
            source.PlayOneShot(helpUs);
        }

        if ( timer > 28 &&  source.isPlaying == false)
        {
  
            source.PlayOneShot(helpMe);
            timer = 0;
        }

        Debug.Log(""+timer);
        timer += Time.deltaTime;
    }
}
