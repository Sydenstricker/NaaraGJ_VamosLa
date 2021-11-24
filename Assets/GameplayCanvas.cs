using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayCanvas : MonoBehaviour
{
    [SerializeField] GameObject deathMenu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AtivaMenuMorte()
    {
        deathMenu.SetActive(true);
    }
}
