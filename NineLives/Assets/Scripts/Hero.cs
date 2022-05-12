using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    //[SerializeField] private CharacterController controller;
    //[SerializeField] public Animator animator;
    //2D Animation in Unity (Tutorial)

    [SerializeField] private float speed = 3f; //скорость 
    [SerializeField] private int lives; // кол-во жизней

    private Rigidbody2D rb; //ссылаемс€ на rb
    private SpriteRenderer sprite; //ссылаемс€ на sr

    [SerializeField] private float jumpForce = 0.15f; //сила прыжка
    private bool isGrounded = false; //переменна€ дл€ проверки земли под ногами
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField] private float timeToDown = 0.5f;
   
    public static Hero Instance { get; set; }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent берет rigidbody с gameobject, всЄ норм
        sprite = GetComponentInChildren<SpriteRenderer>(); //т.к. spriterender находитс€ не на gameobject, а находитс€ в его иерархии мы юзаем getcomponentinchildren
        Instance = this;
    }

    void Update()
    {
        lives = PlayerInteraction.Instance.health;

        CheckGround();

        Move();

        Jump();
        
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //задание движени€

            sprite.flipX = dir.x < 0.0f; //обращаемс€ к замечательному свойству спрайта flipX, которое отзеркаливает персонажа, если он идЄт в другую сторону
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreLayerOff", timeToDown);
        }

        if (isGrounded && Input.GetButton("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    //метод дл€ проверки земли под ногами (чтоб перс от воздуха не прыгал)
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
