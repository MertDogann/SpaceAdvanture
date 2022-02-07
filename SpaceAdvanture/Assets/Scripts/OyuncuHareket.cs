using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuHareket : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator animator;
    Vector2 velocity;
    [SerializeField] float hiz;
    [SerializeField] float joystickHiz;
    [SerializeField] float hizlanma;
    [SerializeField] float joystickHizlanma;
    [SerializeField] float yavaslama;
    [SerializeField] float ziplamaGücü;
    int ziplamaSayisi;
    [SerializeField] int ziplamaLimiti;
    Joystick joystick;
    JoystickButon joystickButon;
    bool zipliyor;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joystickButon = FindObjectOfType<JoystickButon>();
    }

    void Update()
    {
#if UNITY_EDITOR
        KlavyeKontrol();
#else
                JoystickKontrol();
#endif

    }
    void KlavyeKontrol()
    {
            float hareketInput = Input.GetAxisRaw("Horizontal");
            Vector2 scale = transform.localScale;
            if (hareketInput > 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, hiz * hareketInput, hizlanma * Time.deltaTime);
                animator.SetBool("Walk", true);
                scale.x = 0.3f;
            }
            else if (hareketInput < 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, hiz * hareketInput, hizlanma * Time.deltaTime);
                animator.SetBool("Walk", true);
                scale.x = -0.3f;
            }
            else
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
                animator.SetBool("Walk", false);
            }
            transform.localScale = scale;
            transform.Translate(velocity * Time.deltaTime);
            if (Input.GetKeyDown("space"))
            {
                ZiplamayiBaslat();
            }
        if (Input.GetKeyUp("space"))
        {
            ZiplamayýDurdur();
        }
    }
    void JoystickKontrol()
    {
        float hareketInput = joystick.Horizontal;
        Vector2 scale = transform.localScale;
        
        if (hareketInput > 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, joystickHiz * hareketInput, Time.deltaTime * joystickHizlanma);
            animator.SetBool("Walk", true);
            scale.x = 0.3f;
        }else if (hareketInput < 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, joystickHiz * hareketInput, joystickHizlanma * Time.deltaTime);
            animator.SetBool("Walk", true);
            scale.x = -0.3f;
        }else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, yavaslama * Time.deltaTime);
            animator.SetBool("Walk", false);
        }
        transform.Translate(Time.time * velocity);
        transform.localScale = scale;
        if (joystickButon.tusaBasildi == true && zipliyor == false)
        {
            ZiplamayiBaslat();
            zipliyor = true;
        }
        if (joystickButon.tusaBasildi==false && zipliyor == true)
        {
            ZiplamayýDurdur();
            zipliyor = false;
        }
        
    }
    void ZiplamayiBaslat()
    {
        if (ziplamaSayisi< ziplamaLimiti)
        {
            rb2D.AddForce(new Vector2(0, ziplamaGücü), ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
            
        }
    }
    void ZiplamayýDurdur()
    {
        animator.SetBool("Jump", false);
        ziplamaSayisi++;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        
    }
    public void ZiplamaSifirla()
    {
        ziplamaSayisi = 0;
        FindObjectOfType<SliderKontrol>().SliderDeger(ziplamaLimiti, ziplamaSayisi);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Olum")
        {
            FindObjectOfType<Olum>().OyunBitti();
 
        }
    }
    public void OyunBitti()
    {
        Destroy(gameObject);
    }
}
