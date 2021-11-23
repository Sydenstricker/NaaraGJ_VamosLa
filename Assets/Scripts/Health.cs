using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 300;
    [SerializeField] bool isPlayer = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
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
                Destroy(gameObject);
            }
            else
            Destroy(gameObject);
        }
    }
}
