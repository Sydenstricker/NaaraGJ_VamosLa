using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class Health : MonoBehaviour
{
    public StudioEventEmitter emmiterDamage;
    [SerializeField] int health = 300;
    [SerializeField] int folego = 300;
    [SerializeField] bool isPlayer = false;
    [SerializeField] GameObject player;
    public int currentFolego;
    public OxigenBar oxigenBar;    
    private bool perdeu1hp = false;
    private bool perdeu2hp = false;
    private bool perdeu3hp = false;
    public bool semDano = false;
    private void Start()
    {
        currentFolego = folego;
        if (oxigenBar)
        {
            oxigenBar.SetMaxHealth(folego);
        }
    }
    private void Update()
    {
        if(folego <=0)
        {
            if (isPlayer)
            {
                //FindObjectOfType<SFXManager>().DeathSFX();
                player.SetActive(false);
                FindObjectOfType<GameplayCanvas>().AtivaMenuMorte();
                //Destroy(gameObject);
            }
        }
        //Picar dano
        if (semDano)
            StartCoroutine(On_Off_Player(0.02f));
        
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //dano enemie
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        Folego folegoV = other.GetComponent<Folego>();
        if (damageDealer != null)
        {
            if (semDano == false && health > 0)
            {
                StartCoroutine(ControlDamage(3, damageDealer));
                           
                if (perdeu1hp == false)
                {
                    FindObjectOfType<ControladorCoracaoHUD>().Perdeu1HP();
                    perdeu1hp = true;
                    return;
                }
                if (perdeu2hp == false)
                {
                    FindObjectOfType<ControladorCoracaoHUD>().Perdeu2HP();
                    perdeu2hp = true;
                    return;
                }
                if (perdeu3hp == false)
                {
                    FindObjectOfType<ControladorCoracaoHUD>().Perdeu3HP();
                    perdeu3hp = true;
                    return;
                }
            }
        }
        //dano folego
        if (folegoV != null)
        {
            folego -= folegoV.GetDamage();
            currentFolego -= folegoV.GetDamage();
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
            currentFolego -= folegoV.GetDamage();
            oxigenBar.SetHealth(currentFolego);
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
                currentFolego += folegoCura.CuraFolego();
                oxigenBar.SetHealth(currentFolego);
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
        if (emmiterDamage)
        {
            emmiterDamage.Play();
        }

        if (health <= 0)
        {
            if (isPlayer)
            {
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
                //FindObjectOfType<SFXManager>().DeathSFX();
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
    IEnumerator ControlDamage(float delay, DamageDealer damageDealer)
    {
        TakeDamage(damageDealer.GetDamage());
        semDano = true;
        yield return new WaitForSeconds((delay));
        semDano = false;
    }

    IEnumerator On_Off_Player(float delay)
    {
        player.GetComponentInChildren<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds((delay));
        player.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
}
