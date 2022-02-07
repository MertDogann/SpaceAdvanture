using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHareket : MonoBehaviour
{
    float hiz;
    float hizlanma;
    float maksimumHiz;
    bool hareket = true;
    
    void Start()
    {
        if (Secenekler.KolayDegerOku()== 1)
        {
            hiz = 0.5f;
            hizlanma = 0.02f;
            maksimumHiz = 2f;
        }
        if(Secenekler.OrtaDegerOku()== 1)
        {
            hiz = 1f;
            hizlanma = 0.02f;
            maksimumHiz = 4f;
        }
        if (Secenekler.ZorDegerOku()== 1)
        {
            hiz = 2.2f;
            hizlanma = 0.04f;
            maksimumHiz = 5f;
        }
    }

    void Update()
    {
        if (hareket)
        {
           CameraHareketControl();
        }
    }
    void CameraHareketControl()
    {
        transform.position += transform.up * hiz * Time.deltaTime;
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maksimumHiz)
        {
            hiz = maksimumHiz;
        }
    }
}
