using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject item1Menu;
    public GameObject player;
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
    public void AtivaItem1()
    {
        Time.timeScale = 0f;
        item1Menu.SetActive(true);
        player.SetActive(false);
    }
    public void Retorna()
    {
        Time.timeScale = 1f;
        player.SetActive(true);
        item1Menu.SetActive(false);
    }
}
