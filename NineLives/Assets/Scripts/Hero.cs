using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //скорость 
    //[SerializeField] private int lives = 9; // кол-во жизней
    [SerializeField] public float jumpForce = 0.1f; //сила прыжка
    private bool isGrounded = false; //переменна€ дл€ проверки земли под ногами

    private Rigidbody2D rb; //ссылаемс€ на rb
    private SpriteRenderer sprite; //ссылаемс€ на sr

    //реализаци€ синглтона (почитайте, мне лень тут обь€сн€ть), чтобы не создавать каждый раз экземпл€р класса, а обращатьс€ напр€мую
    public static Hero Instance { get; set; }

    private void FixedUpdate()
    {
        CheckGround();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent берет rigidbody с gameobject, всЄ норм
        sprite = GetComponentInChildren<SpriteRenderer>(); //т.к. spriterender находитс€ не на gameobject, а находитс€ в его иерархии мы юзаем getcomponentinchildren
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
            Move();
        if (isGrounded && Input.GetButton("Jump"))
            jump();
    }

    private void Move()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //задание движени€

        sprite.flipX = dir.x < 0.0f; //обращаемс€ к замечательному свойству спрайта flipX, которое отзеркаливает персонажа, если он идЄт в другую сторону
    }

    private void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    //метод дл€ проверки земли под ногами (чтоб перс от воздуха не прыгал)
    //создание массива коллайдеров, который собирает в себ€ количество объектов под ногами
    private void CheckGround()
    {
        //Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f); //смещение координат у персонажа, чтобы находить землю пр€м снизу
        //isGrounded = collider.Length > 1; //если объектов больше одного под персом, то он на земле (первичное значение пока)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = colliders.Length > 1;
    }
}
