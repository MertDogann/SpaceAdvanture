using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlan : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 tempScale = transform.localScale;

        float spriteGenislik = spriteRenderer.size.x;
        float cameraYukseklik = Camera.main.orthographicSize * 2.0f;
        float cameraGenislik = cameraYukseklik / Screen.height * Screen.width;
        tempScale.x = cameraGenislik / spriteGenislik;
        transform.localScale = tempScale;


    }
}
