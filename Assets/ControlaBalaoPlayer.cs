using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBalaoPlayer : MonoBehaviour
{
    [SerializeField] GameObject monologo1;

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
    }
    IEnumerator AtivaTelaItem1(float tempoOn)
    {
        monologo1.SetActive(true);        
        yield return new WaitForSeconds(tempoOn);
        //monologo1.SetActive(false);
        //yield return null;
        monologo1.SetActive(false);
    }
}
