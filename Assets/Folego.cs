using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folego : MonoBehaviour
{
    [SerializeField] int damageFolego = 1;

    public int GetDamage()
    {
        return damageFolego;
    }
    public void Hit()
    {
        return;
        //return damageFolego;
        //Destroy(gameObject);
    }
}
