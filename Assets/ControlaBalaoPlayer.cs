using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControlaBalaoPlayer : MonoBehaviour
{
    [SerializeField] GameObject npcComItem;
    [SerializeField] GameObject npcSemItem;
    [SerializeField] GameObject monologo1;
    [SerializeField] GameObject monologo2;
    [SerializeField] private bool temItem = false;
    public List<colletable> getItem;
    [SerializeField] float tempDialogNPC;
    [SerializeField] GameObject qualItemRecebe;
    private void AtivaTelaItem1()
    {
        monologo1.SetActive(true);
        new WaitForSeconds(4f);
        //Destroy(monologo1);
    }
    private void AtivaTelaItem2()
    {
        monologo2.SetActive(true);
        new WaitForSeconds(4f);
        //Destroy(monologo1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Monologo player
        if(collision.gameObject.CompareTag("Monologo1"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem1(4f));
        } 

        if(collision.gameObject.CompareTag("Monologo2"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem2(4f));
        }

        //Dialog NPC
        if(collision.gameObject.CompareTag("NPC"))
        {
            getItem = GetComponent<inventory>().colletablesList;
            if(getItem.Count == 0)
            {
                temItem = false;
                npcSemItem.SetActive(true);
                Invoke("OcultarDialogNPC", tempDialogNPC);
            }
            else
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
            monologo2.SetActive(true);
            yield return new WaitForSeconds(tempoOn);
            //monologo1.SetActive(false);
            //yield return null;
            //monologo1.SetActive(false);
            Destroy(monologo2);
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
