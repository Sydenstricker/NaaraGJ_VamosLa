<<<<<<< Updated upstream
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
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private Animator animatorPorco;
    [SerializeField] bool ehParaDesaparecerQuandoMorre = false;
    [SerializeField] bool isInimigo = false;
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
            if(isInimigo)
            {
                Debug.Log("dano ao player");
                Destroy(gameObject);
            }
            else
            {
                return;
            }
        }
    }   
}
>>>>>>> Stashed changes
