using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltinAlgilayici : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ayaklar")
        {
            GetComponentInParent<Altin>().AltinKapa();
            FindObjectOfType<Puan>().AltinPuan();
        }
    }
}
