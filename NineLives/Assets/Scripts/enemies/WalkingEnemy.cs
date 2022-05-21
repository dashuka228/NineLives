using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    [SerializeField] private int damageE; //����
    [SerializeField] private float speed; //��������

    [SerializeField] private Vector3[] positions; //������ ������� 
    [SerializeField] private Vector3 dir; //���������� �������
    private int currentTarget; //������� ���� ��� ������������



    public void FixedUpdate()
    {
        Moving();
    }
    
    //�������� �� ������������ � ����������
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.TakeDamage(damageE);
        }
    }

    //������������ 
    private void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);
        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
                currentTarget++;

            else
                currentTarget = 0;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

}
