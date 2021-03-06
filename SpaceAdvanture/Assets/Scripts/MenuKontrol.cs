using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuKontrol : MonoBehaviour
{
    [SerializeField] Sprite[] muzikİkonlar;
    [SerializeField] Button muzikButton;
    bool muzikAcık = true;
    private void Start()
    {
        if (Secenekler.KayitVarmı() == false) 
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
        if (muzikAcık)
        {
            muzikAcık = false;
            muzikButton.image.sprite = muzikİkonlar[0];
        }else
        {
            muzikAcık = true;
            muzikButton.image.sprite = muzikİkonlar[1];
        }
    }
}
