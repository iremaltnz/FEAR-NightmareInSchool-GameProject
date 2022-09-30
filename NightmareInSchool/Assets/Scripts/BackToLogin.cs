using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToLogin : MonoBehaviour
{
    // Start is called before the first frame update
   public void BackToLoginScreen()
    {
        SceneManager.LoadScene("GameScene");

    }
}
