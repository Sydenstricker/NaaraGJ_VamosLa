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
    public inventory getItem;
    private void AtivaTelaItem1()
    {
        monologo1.SetActive(true);
        new WaitForSeconds(4f);
        //Destroy(monologo1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Monologo1"))
        {
            //AtivaTelaItem1();
            StartCoroutine(AtivaTelaItem1(4f));
        }
        if(collision.gameObject.CompareTag("NPC"))
        {
            //getItem = GetComponent<inventory>();
            //foreach (colletable item in getItem.colletablesList)
            //{
            //   if(item.tag == "item1")
            //   {
            //      temItem = true;
            //   }
            //   else
            //   {
            //        temItem = true;
            //   }
            //}
            npcSemItem.SetActive(true);
            if(temItem == true)
            {
                npcComItem.SetActive(true);
            }
        }
        if(collision.gameObject.CompareTag("Item1"))
        {
            FindObjectOfType<GameManager>().AtivaItem1();
            Debug.Log("ativa item 1 menu");            
        }
    }
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
    public void ConsegiuItemNPC()
    {
        temItem = true;
    }
}
