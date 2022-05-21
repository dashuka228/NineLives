using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float jumpForce; //сила прыжка для jump pad

    private void Update()
    {
        animator = GetComponent<Animator>();    
    }

    //Проверка на столкновение с персонажем
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hero"))
        {
            Hero.Instance.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.Play("Add force", 0, 0f);
        }
    }
}   
