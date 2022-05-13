using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    //[SerializeField] private CharacterController controller;
    //[SerializeField] public Animator animator;
    //2D Animation in Unity (Tutorial)

    //����������
    public Rigidbody2D rb; 
    private SpriteRenderer sprite; 

    //��������
    [SerializeField] private float speed = 3f; //�������� 
    [SerializeField] private int lives; // ���������� ������ 
    [SerializeField] private float jumpForce = 0.15f; //���� ������

    //GROUND CHECK
    private bool isGrounded = false; 
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;

    //���������
    [SerializeField] private float timeToDown = 0.5f; //�������� ������ � ���������
   
    //�������� ������ � �������
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
    }


    //��������
    private void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 dir = transform.right * Input.GetAxis("Horizontal");

            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //������� ��������

            sprite.flipX = dir.x < 0.0f; //���������� � �������������� �������� ������� flipX, ������� ������������� ���������, ���� �� ��� � ������ �������
        }
    }

    //������
    private void Jump(float jumpForce)
    {
        if (isGrounded && Input.GetButton("Jump") && (rb.velocity.y == 0)) //������ ��������� ��� ������ ������� � ����� �����. ������ ������...
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //�������� �����
    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
    }
    
    //����� � ���������
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
