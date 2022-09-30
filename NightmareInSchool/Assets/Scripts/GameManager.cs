using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update

        public static GameManager instance;
        public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

        public GameObject localPlayerPrefab;
        public GameObject playerPrefab;

        public GameObject zombie;
        
        public GameObject serverFull;
        public GameObject startMenu;
        public GameObject gameOverScreen;
        public GameObject gameWinScreen;


        public Text floorInfo;
        public Text timer;

        public GameObject oneToTwo;
        public GameObject oneToTwo_2;
        public GameObject oneToTwo_3;

        public GameObject twoToThree;
        public GameObject twoToThree_2;
        public GameObject twoToThree_3;

        public GameObject threeToFour;
        public GameObject threeToFour_2;
        public GameObject threeToFour_3;

        public Text green;
        public Text blue;
        public Text red;

        public Text chat;

        public Text professor;

     
 
        public void Update()
        {
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;

            }
            else if (instance != this)
            {
                Debug.Log("Zaten var");
                Destroy(this);
            }



        }

        public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
        {
            GameObject _player;
            GameObject _zombie;
            GameObject _zombie2;

            


            if (_id == Client.instance.myId)
            {
                instance.serverFull.SetActive(false);
                instance.startMenu.SetActive(false);
              
                _player = Instantiate(localPlayerPrefab, _position, _rotation);
                _player.name = "MaleCharacter";

                _player.GetComponent<PlayerController1>().floorInfo = floorInfo;


                oneToTwo.GetComponent<PassScript>().player = _player;
                oneToTwo_2.GetComponent<PassScript>().player = _player;
                oneToTwo_3.GetComponent<PassScript>().player = _player;

                twoToThree.GetComponent<PassScript>().player = _player;
                twoToThree_2.GetComponent<PassScript>().player = _player;
                twoToThree_3.GetComponent<PassScript>().player = _player;

                threeToFour.GetComponent<PassScript>().player = _player;
                threeToFour_2.GetComponent<PassScript>().player = _player;
                threeToFour_3.GetComponent<PassScript>().player = _player;


                _player.GetComponent<PlayerController1>().green = green;
                _player.GetComponent<PlayerController1>().blue = blue;
                _player.GetComponent<PlayerController1>().red = red;

                _player.GetComponent<PlayerController1>().gameWinScreen = gameWinScreen;

                _player.GetComponent<PlayerController1>().prof = professor;

                _zombie = Instantiate(zombie, new Vector3((float)347.0166, (float)18.51875, (float)310.6463), Quaternion.identity);
                _zombie2 = Instantiate(zombie, new Vector3((float)154.934, (float)-16.78125, (float)-51.44749), Quaternion.identity);
               
                _zombie.GetComponent<ZombieController>().character = _player.transform;
                _zombie.GetComponent<ZombieController>().timer = timer;
                _zombie.GetComponent<ZombieController>().gameOverScreen = gameOverScreen;
              
                _zombie2.GetComponent<ZombieController>().gameOverScreen = gameOverScreen;
               
                _zombie2.GetComponent<ZombieController>().character = _player.transform;
                _zombie2.GetComponent<ZombieController>().timer = timer;


            }
            else
            {

                _player = Instantiate(playerPrefab, _position, _rotation);
            }

            _player.GetComponent<PlayerManager>().id = _id;
            _player.GetComponent<PlayerManager>().username = _username;
            players.Add(_id, _player.GetComponent<PlayerManager>());
        }

        public void SetText(string msg)
        {
            Debug.Log(""+msg);
            chat.text = "" + msg;
    }
    }
}
