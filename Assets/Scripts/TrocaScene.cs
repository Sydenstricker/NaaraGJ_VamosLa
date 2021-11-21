using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocaScene : MonoBehaviour
{
    public int MainMenu;
    private float tempoMudaScene = 5f;    
    void Start()
    {
        Invoke("Change_Scene", tempoMudaScene);
    }
    void Change_Scene()
    {
        SceneManager.LoadScene(MainMenu);
    }
}
