using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 200;
    PolygonCollider2D polygonCollider2D;

    //[Header("NAO MEXER UI Player")]
    //os 2 sao pra barra do coracao
    //public HealthBar healthBar;
    //public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        Time.timeScale = 1f;
        Cursor.visible = false;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void TomarDano(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        //currenthealth é a vida da barra com coraçao, health era ref em string
        //currentHealth = health;
        //healthBar.SetHealth(currentHealth);
        if (health <= 0)
        {
            PlayerMorreu();
        }
    }
    private void PlayerMorreu()
    {
        Time.timeScale = 0.1f;
    }
    public int GetHealth()
    {
        return health;
    }
    public void PlayerVenceuFicaImortal()
    {
        polygonCollider2D.enabled = false;
    }
}
