using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareketController : MonoBehaviour
{
    float arkaPlanKonum;
    float mesafe = 10.24f;
    void Start()
    {
        arkaPlanKonum = transform.position.y;
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
    }

    void Update()
    {
        if (arkaPlanKonum + mesafe < Camera.main.transform.position.y)
        {
            ArkaPlanHareket();
        }
    }
    void ArkaPlanHareket()
    {
        arkaPlanKonum += (mesafe * 2);
        FindObjectOfType<Gezegenler>().GezegenYerlestir(arkaPlanKonum);
        Vector2 hareket = new Vector2(0, arkaPlanKonum);
        transform.position = hareket;
    }
}
