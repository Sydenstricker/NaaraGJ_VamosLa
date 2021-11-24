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
            SceneManager.LoadScene("Intro Gameplay");
            FindObjectOfType<AudioManager>().TocaMusicaGameplay();

        }
    }
}
