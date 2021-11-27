using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class MenuFase : MonoBehaviour
{
    public void PlayAgain()
    {
        GameObject.Find("DeathMenu").SetActive(false);
        SceneManager.LoadScene("fase01_mine");
        //colocar um evento que pare todos audio
        //depois colocar para tocar a musica principal de novo
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void SairGame()
    {
        Application.Quit();
    }
}
