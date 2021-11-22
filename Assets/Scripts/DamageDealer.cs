using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Animator animatorPorco;
    [SerializeField] bool ehParaDesaparecerQuandoMorre = false;
    [SerializeField] int damage = 100;    
    [SerializeField] bool isHP = false;    

    private void Start()
    {
        animatorPorco = GetComponent<Animator>();
    }
    public int GetDamage()
    {
        return damage;
    }
    public void Hit()
    {
        //if (gameObject.CompareTag("Tiro Boss")) { tiroBoss.SetTrigger("acertou"); return; }
       
        if (ehParaDesaparecerQuandoMorre)
        {            
            if (isHP)
            {
                FindObjectOfType<AudioManager>().HPNave();
                Destroy(gameObject);

            }            
            else
            {
                return;
            }
        }
    }   
}
