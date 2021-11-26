using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressEnter : MonoBehaviour
{
    [SerializeField] bool isMainMenu = false;
    
    void Update()
    {
        if(isMainMenu && Input.GetKeyDown(KeyCode.Return))
        {
//<<<<<<< HEAD
//            SceneManager.LoadScene("Test Scene");
//            //FindObjectOfType<AudioManager>().TocaMusicaGameplay();
//=======
//            SceneManager.LoadScene("Intro Gameplay");
//            //FindObjectOfType<AudioManager>().TocaMusicaGameplay();
//>>>>>>> 8a77b7197d3531eb3959b503e9bcf57f3fc14132

        }
    }
}
