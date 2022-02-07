using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Olum : MonoBehaviour
{
    public GameObject ziplama;
    public GameObject joystick;
    public GameObject tabela;
    public GameObject altin;
    public GameObject slider;
    public GameObject oyunBitti;
    public GameObject anaMenu;
    
    
    void Start()
    {
        oyunBitti.SetActive(false);
        UIAc();
        
    }
    

    void Update()
    {
        
    }
    public void OyunBitti()
    {
        
        oyunBitti.SetActive(true);
        FindObjectOfType<Puan>().OyunBitti();
        FindObjectOfType<OyuncuHareket>().OyunBitti();
        UIKapat();
        
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }
    public void TekrarOyna()
    {
        SceneManager.LoadScene("Oyun");
    }
    void UIAc()
    {
        ziplama.SetActive(true);
        joystick.SetActive(true);
        tabela.SetActive(true);
        altin.SetActive(true);
        slider.SetActive(true);
        anaMenu.SetActive(true);
    }
    void UIKapat()
    {
        ziplama.SetActive(false);
        joystick.SetActive(false);
        tabela.SetActive(false);
        altin.SetActive(false);
        slider.SetActive(false);
        anaMenu.SetActive(false);
    }
   
}
