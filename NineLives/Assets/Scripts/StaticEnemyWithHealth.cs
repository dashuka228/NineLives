using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyWithHealth : MonoBehaviour
{

    [SerializeField] private int health = 3; //�������� 
    [SerializeField] private int damageE = 1; //����


    //���� ������� ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.TakeDamage(damageE);
        }
    }

    //���� ��������� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "hero")
        {
            TakeDamageE(PlayerInteraction.Instance.damage);
            Debug.Log("����� ������");
        }
    }

    //�������� �����
    private void TakeDamageE(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    //������
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
