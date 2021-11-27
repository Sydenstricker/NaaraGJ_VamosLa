using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class GameManagerMenuPrinc : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartGame() 
   {
        SceneManager.LoadScene("Intro Gameplay");
   }

   public void Voltar()
   {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(sceneIndex);
    }

    public void CreditoGame()
    {
        SceneManager.LoadScene("Creditos");
        
    }
    public void SairGame()
    {
        Application.Quit();
    }
}
