using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //�������� 
    [SerializeField] private int lives; // ���-�� ������
    [SerializeField] public float jumpForce = 0.15f; //���� ������
    private bool isGrounded = false; //���������� ��� �������� ����� ��� ������
    private float groundRadius = 0.3f;
    public Transform groundCheck;
    public LayerMask groundMask;
    private Rigidbody2D rb; //��������� �� rb
    private SpriteRenderer sprite; //��������� �� sr

    public static Hero Instance { get; set; }

    private void FixedUpdate()
    {
        //CheckGround();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent ����� rigidbody � gameobject, �� ����
        sprite = GetComponentInChildren<SpriteRenderer>(); //�.�. spriterender ��������� �� �� gameobject, � ��������� � ��� �������� �� ����� getcomponentinchildren
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundMask);
        lives = PlayerInteraction.Instance.health;

        if (Input.GetButton("Horizontal"))
            Move();
        if (isGrounded && Input.GetButton("Jump"))
            Jump();

    }

    private void Move()
    {
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //������� ��������

        sprite.flipX = dir.x < 0.0f; //���������� � �������������� �������� ������� flipX, ������� ������������� ���������, ���� �� ��� � ������ �������
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    //����� ��� �������� ����� ��� ������ (���� ���� �� ������� �� ������)
    //�������� ������� �����������, ������� �������� � ���� ���������� �������� ��� ������

    /*
    private void CheckGround()
    {
        //Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f); //�������� ��������� � ���������, ����� �������� ����� ���� �����
        //isGrounded = collider.Length > 1; //���� �������� ������ ������ ��� ������, �� �� �� ����� (��������� �������� ����)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = colliders.Length > 1;
    }
    */
}
