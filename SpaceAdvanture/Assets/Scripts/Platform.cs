using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PolygonCollider2D polygonCollider;
    bool hareket ;
    float randomHiz;
    float min, max;

    public bool Hareket
    {
        get
        {
            return hareket;
        }
        set
        {
            hareket = value;
        }
    }
    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();

        if (Secenekler.KolayDegerOku() == 1)
        {
            randomHiz = Random.Range(0.2f, 0.6f);
        }
        if (Secenekler.OrtaDegerOku() == 1)
        {
            randomHiz = Random.Range(0.3f, 1.0f);
        }
        if (Secenekler.ZorDegerOku() == 1)
        {
            randomHiz = Random.Range(0.8f, 1.8f);
        }
        float objeGenislik = polygonCollider.bounds.size.x / 2;
        if (transform.position.x > 0)
        {
            min = objeGenislik;
            max = EkranHesaplayicisi.instance.Genislik - objeGenislik;

        }else
        {
            min = -EkranHesaplayicisi.instance.Genislik + objeGenislik;
            max = -objeGenislik;
        }
    }

    void Update()
    {
        if (hareket)
        {
            float pingPongx = Mathf.PingPong(Time.time*randomHiz, (max-min) )+min;
            Vector2 pingPong = new Vector2(pingPongx, transform.position.y);
            transform.position = pingPong;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag== ("Ayaklar"))
        {
            GameObject.FindGameObjectWithTag("Player").transform.parent = transform;
            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<OyuncuHareket>().ZiplamaSifirla();
        }
    }
}
