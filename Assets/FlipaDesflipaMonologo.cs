using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipaDesflipaMonologo : MonoBehaviour
{
    /*private SpriteRenderer monologo;
    void Start()
    {
        monologo = GetComponent<SpriteRenderer>();
    }*/

    // Update is called once per frame
    void Update()
    {
        if(transform.eulerAngles != Vector3.zero)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }
}
