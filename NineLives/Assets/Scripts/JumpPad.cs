using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce; //���� ������ ��� jump pad

    //�������� �� ������������ � ����������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            Hero.Instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}   
