using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteR;

    [SerializeField] private float timeToFall; //через сколько платформа начнет падать
    [SerializeField] private Sprite[] sprites;

    private int[] layers; //слои, об которые платформа разрушается

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[0]; 
        layers = new int[] { 6, 8, 9 };

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Проверка на столкновение с персонажем
        if (collision.gameObject.tag == "hero" && Hero.Instance.rb.velocity.y == 0)
        {
            Invoke("FallPlatform", timeToFall);
        }

        //проверка на столкновение с определенными объектами для разрушения платформы
        else
        {
            if (layers.Contains(collision.gameObject.layer))
            {
                Destroy(gameObject);
            }
        }
    }

    //ПАДЕНИЕ ПЛАТФОРМЫ
    private void FallPlatform ()
    {
        rb.isKinematic = false;
        spriteR.sprite = sprites[1]; 
        Invoke("ChangeSprite", 0.5f);
    }

    //МЕТОД ЗАМЕНЫ СПРАЙТА ВО ВРЕМЯ ПОЛЕТА
    private void ChangeSprite ()
    {
        spriteR.sprite = sprites[2];
    }
}
