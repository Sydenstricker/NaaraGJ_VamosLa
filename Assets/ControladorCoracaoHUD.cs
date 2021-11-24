using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCoracaoHUD : MonoBehaviour
{
    [SerializeField] GameObject coracao1;
    [SerializeField] GameObject coracao2;
    [SerializeField] GameObject coracao3;

   public void Perdeu1HP()
    {
        coracao1.SetActive(false);
    }
    public void Perdeu2HP()
    {
        coracao2.SetActive(false);
    }
    public void Perdeu3HP()
    {
        coracao3.SetActive(false);
    }
}
