using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puan : MonoBehaviour
{
    [SerializeField] Text puanText;
    int puan;
    int enYuksekPuan;
    [SerializeField] Text altinText;
    int altin;
    int enYuksekAltin;
    [SerializeField] Text oyunBittiPuanText;
    [SerializeField] Text oyunBittiAltinText;
    bool puanTopla = true;
    void Start()
    {
        altinText.text = " X " + altin;
    }

    void Update()
    {
        if (puanTopla)
        {
            puan = (int)Camera.main.transform.position.y * 2;
            puanText.text = "Puan: " + puan;
        }
    }
    public void AltinPuan()
    {
        altin++;
        altinText.text = " X " + altin;
    }
    public void OyunBitti()
    {
        if (Secenekler.KolayDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.KolayPuanDegerOku();
            enYuksekAltin = Secenekler.KolayAltinDegerOku();
            if (puan > enYuksekPuan)
            {
                Secenekler.KolayPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.KolayAltinDegerAta(altin);
            }
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.OrtaPuanDegerOku();
            enYuksekAltin = Secenekler.OrtaAltinDegerOku();
            if(puan > enYuksekPuan)
            {
                Secenekler.OrtaPuanDegerAta(puan);
            }
            if (altin > enYuksekAltin)
            {
                Secenekler.OrtaAltinDegerAta(altin);
            }
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            enYuksekPuan = Secenekler.ZorPuanDegerOku();
            enYuksekAltin = Secenekler.ZorAltinDegerOku();
            if(puan> enYuksekPuan)
            {
                Secenekler.ZorPuanDegerAta(puan);
            }
            if (altin> enYuksekAltin)
            {
                Secenekler.ZorAltinDegerAta(altin);
            }
        }
        puanTopla = false;
        oyunBittiPuanText.text = "Puan: " + puan;
        oyunBittiAltinText.text = " X " + altin;
    }
}
