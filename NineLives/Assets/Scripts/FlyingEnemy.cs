using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed; //��������

    [SerializeField] private Vector3[] positions; //������ ������� 
    private int currentTarget; //������� ���� ��� ������������

    [SerializeField] private float timeToDrop; //����� ������� ������ ������� ����� �������������
    [SerializeField] private GameObject objectt; //����� ������ ������� ����� ������
    private GameObject copyObject; //������������� ������
    private bool timer = true; //������ ��� ������ �������


    private void Start()
    {
        copyObject = objectt;
    }

    private void Update()
    {
        if (timer)
        {
            Invoke("Drop", timeToDrop);
            timer = false;
        }
    }

    public void FixedUpdate()
    {
        Moving();
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
            //Drop();
        }
    }

    //������ �������
    private void Drop()
    {
        Instantiate(copyObject, gameObject.transform.position, Quaternion.identity);
        timer = true;
    }
}
