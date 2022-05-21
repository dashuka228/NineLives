using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteR;

    [SerializeField] private float timeToFall; //����� ������� ��������� ������ ������
    [SerializeField] private Sprite[] sprites;

    private int[] layers; //����, �� ������� ��������� �����������

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        spriteR.sprite = sprites[0]; 
        layers = new int[] { 6, 8, 9 };

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�������� �� ������������ � ����������
        if (collision.gameObject.tag == "hero" && Hero.Instance.rb.velocity.y == 0)
        {
            Invoke("FallPlatform", timeToFall);
        }

        //�������� �� ������������ � ������������� ��������� ��� ���������� ���������
        else
        {
            if (layers.Contains(collision.gameObject.layer))
            {
                Destroy(gameObject);
            }
        }
    }

    //������� ���������
    private void FallPlatform ()
    {
        rb.isKinematic = false;
        spriteR.sprite = sprites[1]; 
        Invoke("ChangeSprite", 0.5f);
    }

    //����� ������ ������� �� ����� ������
    private void ChangeSprite ()
    {
        spriteR.sprite = sprites[2];
    }
}
