using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipaDesflipaMonologo : MonoBehaviour
{
    private SpriteRenderer monologo;
    void Start()
    {
        monologo = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("A"))
        {
            Debug.Log("flipou");
        }
        if(Input.GetButtonDown("D"))
        {
            Debug.Log("Desflipou");
        }
    }
}
