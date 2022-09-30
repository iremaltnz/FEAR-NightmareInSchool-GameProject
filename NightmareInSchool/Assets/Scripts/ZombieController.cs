using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ZombieController : MonoBehaviour
{
    public float speed;
    public float distance;
    public bool idle;
   
    public bool run;
    public Transform character;
    Vector3 character_pos;
    Animator animator;

    public Text timer;
    float _time = 15;

    public AudioSource source;
    public AudioClip zombie;

  public GameObject gameOverScreen;
   

    void Start()
    {
        animator = GetComponent<Animator>();
        timer.text = ""+_time;
    }

   
    void Update()
    {
        character_pos = new Vector3(character.position.x, transform.position.y, character.position.z);
        distance = Vector3.Distance(transform.position, character.position);

        if (distance > 50)
        {

            source.Stop();

            _time = 15;
            idle = true;
            run = false;
        }

        if (distance < 50)
        {

          
                if (source.isPlaying == false)
                {
                    source.Play();
                }
            
       


            if ((int)_time == 0)
            {
                UnityEngine.Debug.Log("GameOver");
                Client.TCP tCP = new Client.TCP();
                tCP.Disconnect();
                gameOverScreen.SetActive(true);
            }

            else if ((int)_time >=0)
            {
                _time -= Time.deltaTime;
                timer.text = "" + (int)_time;
                UnityEngine.Debug.Log(_time);
              
            }

            
         
        
            idle = false;
            run = true;


        }
        if (run)
        {
            speed = 3;
            transform.position = Vector3.MoveTowards(transform.position, character.position, speed * Time.deltaTime);
            transform.LookAt(character_pos);
     
            animator.SetBool("walk", true);
            animator.SetBool("idle", false);

        }

        if (run == false)
        {
            animator.SetBool("walk", false);
            animator.SetBool("idle", true);
        }


        
    }



}
