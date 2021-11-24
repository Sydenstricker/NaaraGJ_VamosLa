using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 300;
    [SerializeField] int folego = 300;
    [SerializeField] bool isPlayer = false;
    [SerializeField] GameObject player;
    private void Update()
    {
        if(folego <=0)
        {
            if (isPlayer)
            {
                FindObjectOfType<SFXManager>().DeathSFX();
                player.SetActive(false);
                FindObjectOfType<GameplayCanvas>().AtivaMenuMorte();
                //Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        Folego folegoV = other.GetComponent<Folego>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
        if (folegoV != null)
        {
            folego -= folegoV.GetDamage();
            //TakeFolego(folego.GetDamage());
            //StartCoroutine(DelayFolego(3));
            //folego.Hit();
            Debug.Log("tirou folego");
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Folego folegoV = collision.GetComponent<Folego>();
        AdicionaFolego folegoCura = collision.GetComponent<AdicionaFolego>();
        if (folegoV != null)
        {
            folego -= folegoV.GetDamage();
            //TakeFolego(folego.GetDamage());
            //StartCoroutine(DelayFolego(3));
            //folego.Hit();
            Debug.Log("tirou folego");
        }
        if(folegoCura != null)
        {
            if (folego < 1000)
            {
                folego += folegoCura.CuraFolego();
                Debug.Log("curou folego");
            }
            else
            {
                return;
            }
        }
    }
    
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(isPlayer)
            {
                FindObjectOfType<SFXManager>().DeathSFX();
                player.SetActive(false);
                FindObjectOfType<GameplayCanvas>().AtivaMenuMorte();                
                //Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void TakeFolego(int damageFolego)
    {
        folego =- damageFolego;
        if(folego <= 0)
            if(isPlayer)
            {
                FindObjectOfType<SFXManager>().DeathSFX();
                player.SetActive(false);
                FindObjectOfType<GameplayCanvas>().AtivaMenuMorte();
            }
            else
            {
                Destroy(gameObject);
            }
    }
    IEnumerator DelayFolego(float delay)
    {
        yield return new WaitForSeconds((delay));
    }
}
