using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //скорость 
    [SerializeField] private int lives; // кол-во жизней
    [SerializeField] public float jumpForce = 2f; //сила прыжка
    private bool isGrounded = false; //переменная для проверки земли под ногами

    private Rigidbody2D rb; //ссылаемся на rb
    private SpriteRenderer sprite; //ссылаемся на sr

    public static Hero Instance { get; set; }

    private void FixedUpdate()
    {
        CheckGround();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent берет rigidbody с gameobject, всё норм
        sprite = GetComponentInChildren<SpriteRenderer>(); //т.к. spriterender находится не на gameobject, а находится в его иерархии мы юзаем getcomponentinchildren
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        lives = PlayerInteraction.Instance.health;
        if (Input.GetButton("Horizontal"))
            Move();
        if (isGrounded && Input.GetButton("Jump"))
            jump();

    }

    private void Move()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //задание движения

        sprite.flipX = dir.x < 0.0f; //обращаемся к замечательному свойству спрайта flipX, которое отзеркаливает персонажа, если он идёт в другую сторону
    }

    private void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    //метод для проверки земли под ногами (чтоб перс от воздуха не прыгал)
    //создание массива коллайдеров, который собирает в себя количество объектов под ногами
    private void CheckGround()
    {
        //Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f); //смещение координат у персонажа, чтобы находить землю прям снизу
        //isGrounded = collider.Length > 1; //если объектов больше одного под персом, то он на земле (первичное значение пока)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = colliders.Length > 1;
    }
}
