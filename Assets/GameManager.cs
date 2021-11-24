using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public void VoltarMainMenu()
    {
        FindObjectOfType<AudioManager>().TocaMusicaMainMenu();
        SceneManager.LoadScene("MainMenu");
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Skip()
    {
        SceneManager.LoadScene("Level 1");
    }
}
