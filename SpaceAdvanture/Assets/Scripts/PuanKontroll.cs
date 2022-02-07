using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuanKontroll : MonoBehaviour
{
    [SerializeField] Text kolayPuanText, kolayAltin, ortaPuanText, ortaAltin, zorPuanText, zorAltin;

    void Start()
    {

        kolayPuanText.text = "Puan: " + Secenekler.KolayPuanDegerOku();
        kolayAltin.text = " X " + Secenekler.KolayAltinDegerOku();

        ortaPuanText.text = "Puan: " + Secenekler.OrtaPuanDegerOku();
        ortaAltin.text = " X " + Secenekler.OrtaAltinDegerOku();

        zorPuanText.text = "Puan: " + Secenekler.ZorPuanDegerOku();
        zorAltin.text = " X " + Secenekler.ZorAltinDegerOku();

    }

    void Update()
    {
        
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("Menu");
    }
}
