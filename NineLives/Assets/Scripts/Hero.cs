using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    //[SerializeField] private CharacterController controller;
    //[SerializeField] public Animator animator;
    //2D Animation in Unity (Tutorial)

    [SerializeField] private float speed = 3f; //�������� 
    [SerializeField] private int lives; // ���-�� ������

    private Rigidbody2D rb; //��������� �� rb
    private SpriteRenderer sprite; //��������� �� sr

    [SerializeField] private float jumpForce = 0.15f; //���� ������
    private bool isGrounded = false; //���������� ��� �������� ����� ��� ������
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    [SerializeField] private float timeToDown = 0.5f;
   
    public static Hero Instance { get; set; }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent ����� rigidbody � gameobject, �� ����
        sprite = GetComponentInChildren<SpriteRenderer>(); //�.�. spriterender ��������� �� �� gameobject, � ��������� � ��� �������� �� ����� getcomponentinchildren
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

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //������� ��������

            sprite.flipX = dir.x < 0.0f; //���������� � �������������� �������� ������� flipX, ������� ������������� ���������, ���� �� ��� � ������ �������
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


    //����� ��� �������� ����� ��� ������ (���� ���� �� ������� �� ������)
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }

    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
