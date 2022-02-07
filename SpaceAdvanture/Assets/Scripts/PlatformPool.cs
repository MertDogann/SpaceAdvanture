using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] GameObject platformPrefabs;
    [SerializeField] GameObject playerPrefabs;
    [SerializeField] GameObject olumculPlatformPrefabs;
    List<GameObject> platforms = new List<GameObject>();
    Vector2 platformPozisyon;
    Vector2 playerPozisyon;
    [SerializeField] float sonrakiPlatformAralik;
    void Start()
    {
        PlatformUret();
        
    }

    void Update()
    {
        if (platforms[platforms.Count-1].transform.position.y < Camera.main.transform.position.y + EkranHesaplayicisi.instance.Yukseklik)
        {
            PlatformYerlestir();
        }
    }
    void PlatformUret()
    {
        platformPozisyon = new Vector2(0, 0);
        playerPozisyon = new Vector2(0, 0.5f);
        GameObject player = Instantiate(playerPrefabs, playerPozisyon, Quaternion.identity);
        GameObject ilkPlatform = Instantiate(platformPrefabs, platformPozisyon, Quaternion.identity);
        //platforms.Add(ilkPlatform);
        SonrakiPlatform();
        ilkPlatform.GetComponent<Platform>().Hareket = false ;

        for (int i = 0; i < 9; i++)
        {
            GameObject platform = Instantiate(platformPrefabs, platformPozisyon, Quaternion.identity);
            platforms.Add(platform);
            platform.GetComponent<Platform>().Hareket = true;
            if (i%2 == 0)
            {
                platform.GetComponent<Altin>().AltinAc();
            }
            SonrakiPlatform();
        }
        GameObject olumculPlatform = Instantiate(olumculPlatformPrefabs, platformPozisyon, Quaternion.identity);
        olumculPlatform.GetComponent<OlumculPlatform>().Hareket = true;
        platforms.Add(olumculPlatform);
        SonrakiOlumculPlatform();

    }
    void PlatformYerlestir()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject temp;
            temp = platforms[i + 5];
            platforms[i + 5] = platforms[i];
            platforms[i] = temp;
            platforms[i + 5].transform.position = platformPozisyon;
            SonrakiPlatform();
            
            if(platforms[i+5].gameObject.tag == "Platform")
            {
                platforms[i + 5].GetComponent<Altin>().AltinKapa();
                float random = Random.Range(0.1f, 1.0f);
                if (random > 0.4f)
                {
                    platforms[i + 5].GetComponent<Altin>().AltinAc();
                }
            }
        }
    }
    void SonrakiPlatform()
    {
        platformPozisyon.y += sonrakiPlatformAralik;
        float random = Random.Range(0.1f, 1.0f);
        if (random < 0.6f)
        {
            
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;

        }
        else
        {
            
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }

        
    }
    void SonrakiOlumculPlatform()
    {
        platformPozisyon.y += sonrakiPlatformAralik - 1.5F;
        float random = Random.Range(0.1f, 1.0f);
        if (random < 0.6f)
        {
            platformPozisyon.x = EkranHesaplayicisi.instance.Genislik / 2;

        }
        else
        {
            platformPozisyon.x = -EkranHesaplayicisi.instance.Genislik / 2;
        }
    }
}
