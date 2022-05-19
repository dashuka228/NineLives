using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb; 
    private GameObject platform;
    [SerializeField] private float timeToFall; //через сколько платформа начнет падать
    //[SerializeField] private float timeToDestroy; //через сколько платформа уничтожится

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Проверка на столкновение с персонажем
        if (collision.gameObject.tag == "hero")
        {
            Invoke("FallPlatform", timeToFall);
        }
        
        if (collision.gameObject.layer == 6 || collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    //ПАДЕНИЕ ПЛАТФОРМЫ
    private void FallPlatform ()
    {
        rb.isKinematic = false;
    }

}
