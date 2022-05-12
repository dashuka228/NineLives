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

    public Rigidbody2D rb; //ссылаемся на rb
    private SpriteRenderer sprite; //ссылаемся на sr

    [SerializeField] private float jumpForce = 0.15f; //сила прыжка
    private bool isGrounded = false; //переменная для проверки земли под ногами
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField] private float timeToDown = 0.5f;
   
    public static Hero Instance { get; set; }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent берет rigidbody с gameobject, всё норм
        sprite = GetComponentInChildren<SpriteRenderer>(); //т.к. spriterender находится не на gameobject, а находится в его иерархии мы юзаем getcomponentinchildren
        Instance = this;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        lives = PlayerInteraction.Instance.health;

        Move();

        Jump(jumpForce);
        
    }

    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //задание движения

            sprite.flipX = dir.x < 0.0f; //обращаемся к замечательному свойству спрайта flipX, которое отзеркаливает персонажа, если он идёт в другую сторону
        }
    }

    private void Jump(float jumpForce)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.IgnoreLayerCollision(7, 8, true);
            Invoke("IgnoreLayerOff", timeToDown);
        }

        if (isGrounded && Input.GetButton("Jump") && (rb.velocity.y <= 0)) //ПИЗДЕЦ ПОСТАВЬТЕ ЭТУ СТРОЧКУ В РАМКУ НАХУЙ. ЕБАНЫЙ ПРЫЖОК...
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    //метод для проверки земли под ногами (чтоб перс от воздуха не прыгал)
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
