using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField] Sprite[] muzik�konlar;
    [SerializeField] Button muzikButton;
    bool muzikAc�k = true;
    private void Start()
    {
        if (Secenekler.KayitVarm�() == false) 
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
        if (muzikAc�k)
        {
            muzikAc�k = false;
            muzikButton.image.sprite = muzik�konlar[0];
        }else
        {
            muzikAc�k = true;
            muzikButton.image.sprite = muzik�konlar[1];
        }
    }
}
