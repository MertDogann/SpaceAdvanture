using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField] Sprite[] muzikÝkonlar;
    [SerializeField] Button muzikButton;
    bool muzikAcýk = true;
    private void Start()
    {
        if (Secenekler.KayitVarmý() == false) 
        {
            Secenekler.KolayDegerAta(1);
        }
    }
    public void OyunuBaslat()
    {
        SceneManager.LoadScene("Oyun");
    }
    public void EnYuksekPuan()
    {
        SceneManager.LoadScene("Puan");
    }
    public void Ayarlar()
    {
        SceneManager.LoadScene("Ayarlar");
    }
    public void Muzik()
    {
        if (muzikAcýk)
        {
            muzikAcýk = false;
            muzikButton.image.sprite = muzikÝkonlar[0];
        }else
        {
            muzikAcýk = true;
            muzikButton.image.sprite = muzikÝkonlar[1];
        }
    }
}
