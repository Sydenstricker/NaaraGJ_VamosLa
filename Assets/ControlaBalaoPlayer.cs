using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlaBalaoPlayer : MonoBehaviour
{
    [SerializeField] GameObject npcComItem;
    [SerializeField] GameObject npcSemItem;
    [SerializeField] GameObject monologo1;
    [SerializeField] GameObject monologo2, monologo3, monologo4;
    [SerializeField] private bool temItem = false;
    public List<colletable> getItem;
    [SerializeField] float tempDialogNPC;
    [SerializeField] GameObject qualItemRecebe;
    private void AtivaTelaItem1()
    {
        monologo1.SetActive(true);
        new WaitForSeconds(60f);
        //Destroy(monologo1);
    }
    private void AtivaTelaItem2()
    {
        monologo2.SetActive(true);
        new WaitForSeconds(60f);
        //Destroy(monologo1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Monologo player
        if (collision.gameObject.CompareTag("Monologo1"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem1(30f));
        }

        if (collision.gameObject.CompareTag("Monologo2"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem2(30f));
        }

        if (collision.gameObject.CompareTag("Monologo3"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem3(30f));
        }

        if (collision.gameObject.CompareTag("Monologo4"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem4(20f));
        }

        if (collision.gameObject.CompareTag("DesligaMonologo"))
        {
            //AtivaTelaItem1();
            monologo4.SetActive(false);
            monologo3.SetActive(false);
            monologo2.SetActive(false);
            monologo1.SetActive(false);
        }

        //Dialog NPC
        if (collision.gameObject.CompareTag("NPC"))
        {
            getItem = GetComponent<inventory>().colletablesList;
            if(getItem.Count == 0)
            {
                temItem = false;
                npcSemItem.SetActive(true);
                Invoke("OcultarDialogNPC", tempDialogNPC);
            }
            else if(!temItem)
            {
                temItem = true;
                npcComItem.SetActive(true);
                Invoke("OcultarDialogNPC", tempDialogNPC);
                qualItemRecebe.SetActive(true);


            }
           
          
        }
        //if(collision.gameObject.CompareTag("Item1"))
        //{
        //    FindObjectOfType<GameManager>().AtivaItem1();
        //    Debug.Log("ativa item 1 menu");            
        //}
        
      
    }
    //Monologo 1
    IEnumerator AtivaTelaItem1(float tempoOn)
    {
        if(monologo1 != null)
        {
            //tempoOn = 60f;
            monologo1.SetActive(true);        
            yield return new WaitForSeconds(tempoOn);
            //monologo1.SetActive(false);
            //yield return null;
            //monologo1.SetActive(false);
            Destroy(monologo1);
        }
    }
    //Monologo 2
    IEnumerator AtivaTelaItem2(float tempoOn)
    {
        if (monologo2 != null)
        {
            //tempoOn = 60f;
            if (monologo1.activeInHierarchy)
            {
                monologo1.SetActive(false);
            }
            monologo2.SetActive(true);
            yield return new WaitForSeconds(tempoOn);
            //monologo1.SetActive(false);
            //yield return null;
            //monologo1.SetActive(false);
            Destroy(monologo2);
        }
    }

    IEnumerator AtivaTelaItem3(float tempoOn)
    {
        if (monologo2 != null)
        {
            //tempoOn = 60f;
            if (monologo3.activeInHierarchy)
            {
                monologo3.SetActive(false);
            }
            monologo3.SetActive(true);
            yield return new WaitForSeconds(tempoOn);
            //monologo1.SetActive(false);
            //yield return null;
            //monologo1.SetActive(false);
            Destroy(monologo3);
        }
    }

    IEnumerator AtivaTelaItem4(float tempoOn)
    {
        if (monologo2 != null)
        {
            //tempoOn = 60f;
            if (monologo4.activeInHierarchy)
            {
                monologo4.SetActive(false);
            }
            monologo4.SetActive(true);
            yield return new WaitForSeconds(tempoOn);
            //monologo1.SetActive(false);
            //yield return null;
            //monologo1.SetActive(false);
            Destroy(monologo3);
        }
    }

    void OcultarDialogNPC()
    {
        npcComItem.SetActive(false);
        npcSemItem.SetActive(false);
    }
   
    public void ConsegiuItemNPC()
    {
        temItem = true;
    }
}
