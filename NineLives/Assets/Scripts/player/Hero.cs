using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Hero : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] public Animator animator;
    //2D Animation in Unity (Tutorial)

    //КОМПОНЕНТЫ
    public Rigidbody2D rb; 
    private SpriteRenderer sprite; 

    //ГЕЙМПЛЕЙ
    [SerializeField] private float speed = 3f; //скорость 
    [SerializeField] private int lives; // количество жизней 
    [SerializeField] private float jumpForce = 0.15f; //сила прыжка

    //GROUND CHECK
    private bool isGrounded = false; 
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;

    //ПЛАТФОРМЫ
    [SerializeField] private float timeToDown = 0.5f; //скорость спуска с платформы
   
    //СОЗДАНИЕ ССЫЛКИ К СКРИПТУ
    public static Hero Instance { get; set; }


    private void FixedUpdate()
    {
        CheckGround();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        sprite = GetComponent<SpriteRenderer>(); 
        Instance = this;
    }

    void Update()
    {
        lives = PlayerInteraction.Instance.health;

        Move();

        Jump(jumpForce);

        DownFromThePlatform();

        float horizontalMove = Math.Abs(Input.GetAxisRaw("Horizontal") * speed);
        animator.SetFloat("Speed", horizontalMove);


    }


    //ДВИЖЕНИЕ
    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //задание движения

            sprite.flipX = dir.x < 0.0f; //обращаемся к замечательному свойству спрайта flipX, которое отзеркаливает персонажа, если он идёт в другую сторону
        }
    }

    //ПРЫЖОК
    private void Jump(float jumpForce)
    {
        if (isGrounded && Input.GetButton("Jump") && (rb.velocity.y == 0)) //ПИЗДЕЦ ПОСТАВЬТЕ ЭТО ВТОРОЕ УСЛОВИЕ В РАМКУ НАХУЙ. ЕБАНЫЙ ПРЫЖОК...
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
        }
    }

    //ПРОВЕРКА ЗЕМЛИ
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }
    
    //СПУСК С ПЛАТФОРМЫ
    private void DownFromThePlatform()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreLayerOff", timeToDown);
        }
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
