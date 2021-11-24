using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdicionaFolego : MonoBehaviour
{
    [SerializeField] int curaFolego = 1;

    public int CuraFolego()
    {
        return curaFolego;
    }
    public void Hit()
    {
        return;
        //return damageFolego;
        //Destroy(gameObject);
    }
}
