using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f; //�������� 
    [SerializeField] private int lives = 9; // ���-�� ������
    [SerializeField] public float jumpForce = 2f; //���� ������
    private bool isGrounded = false; //���������� ��� �������� ����� ��� ������

    private Rigidbody2D rb; //��������� �� rb
    private SpriteRenderer sprite; //��������� �� sr

    private void FixedUpdate()
    {
        CheckGround();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //getcomponent ����� rigidbody � gameobject, �� ����
        sprite = GetComponentInChildren<SpriteRenderer>(); //�.�. spriterender ��������� �� �� gameobject, � ��������� � ��� �������� �� ����� getcomponentinchildren
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

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime); //������� ��������

        sprite.flipX = dir.x < 0.0f; //���������� � �������������� �������� ������� flipX, ������� ������������� ���������, ���� �� ��� � ������ �������
    }

    private void jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    //����� ��� �������� ����� ��� ������ (���� ���� �� ������� �� ������)
    //�������� ������� �����������, ������� �������� � ���� ���������� �������� ��� ������
    private void CheckGround()
    {
        //Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f); //�������� ��������� � ���������, ����� �������� ����� ���� �����
        //isGrounded = collider.Length > 1; //���� �������� ������ ������ ��� ������, �� �� �� ����� (��������� �������� ����)

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);

        isGrounded = colliders.Length > 1;
    }
}
