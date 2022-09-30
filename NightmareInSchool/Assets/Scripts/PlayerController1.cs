using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class PlayerController1 : MonoBehaviour
    {
       
        public GameObject _character;
        CharacterController controller;
        public float gravity;
        public Transform ground;
        public float distance = 0.3f;
        bool isGrounded;
        public LayerMask mask;
        Vector3 velocity;
        public Text floorInfo;

        int tempGreen = 0;
        int tempBlue = 0;
        int tempRed = 0;
        int tempProf=0;

        public Text green;
        public Text blue;
        public Text red;

        public Text prof;

        public AudioSource source;
        public AudioClip key;
        public AudioClip step;

        public GameObject gameWinScreen;

        public void Start()
        {
            source =gameObject.GetComponent<AudioSource>();
        }

        private void Update()

        {
            if (prof.text=="3")
            {
                gameWinScreen.SetActive(true);
                Client.TCP client = new Client.TCP();
                client.Disconnect();
                
            }

            if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            {
                if (source.isPlaying == false)
                {
                    source.Play();
                }
            }
            else
            {
                source.Stop();
            }

            float _caharacterPositionY = _character.transform.position.y;


            if (_caharacterPositionY > -20 && _caharacterPositionY < 15)
            {
                floorInfo.text = "1.Kat";
                Debug.Log("1.Kat");
            }

            else if (_caharacterPositionY > 15 && _caharacterPositionY < 45)
            {
                floorInfo.text = "2.Kat";
                Debug.Log("2.Kat");
            }
            else if (_caharacterPositionY > 45 && _caharacterPositionY < 80)
            {
                floorInfo.text = "3.Kat";
                Debug.Log("3.Kat");
            }
            else
            {
                floorInfo.text = "4.Kat";
                Debug.Log("4.Kat");
            }


            #region Gravity

          
            isGrounded = Physics.CheckSphere(ground.position, distance, mask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            #endregion

         

          
        }
        private void FixedUpdate()
        {
            
            SendInputToServer();
        }

        private void SendInputToServer()
        {
           
           

            bool[] _inputs = new bool[]
            {
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
            };


          
            ClientSend.PlayerMovement(_inputs);
          
        }


      public void OnTriggerEnter(Collider col)
        {
            if (col.tag=="KeyGreen")
            {

                source.PlayOneShot(key);

              

                tempGreen++;
                Debug.Log(""+ tempGreen);
                green.text = "Green Key = " + tempGreen;
                Destroy(col.gameObject);
            }

            if (col.tag == "KeyBlue")
            {
                source.PlayOneShot(key);
                tempBlue++;
                Debug.Log("" + tempBlue);

                blue.text = "Blue Key = " + tempBlue;
                Destroy(col.gameObject);
            }

            if (col.tag == "KeyRed")
            {
                source.PlayOneShot(key);
                tempRed++;
                Debug.Log("" + tempRed);

                red.text = "Red Key = " + tempRed;
                Destroy(col.gameObject);
            }

            if (col.tag == "Professor")
            {
                tempProf++;
                prof.text = "" + tempProf;

               
                Destroy(col.gameObject);
            }
        }


     
    }
}
