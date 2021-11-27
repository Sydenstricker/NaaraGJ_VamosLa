using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pepita : MonoBehaviour
{
    public static int multiplicadorOuro = 1;
    [SerializeField]int valor = 10;
    [SerializeField]Text txtTotalOuro;
    private int totalOuro = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            int valorOuro = valor * multiplicadorOuro;
            totalOuro =int.Parse(txtTotalOuro.text) + valorOuro;
            txtTotalOuro.text = totalOuro.ToString();
            Destroy(transform.gameObject);

        }
    }
}
