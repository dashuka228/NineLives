using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemy : MonoBehaviour
{
    [SerializeField] private int damageE; //урон
    [SerializeField] private float speed; //скорость

    [SerializeField] private Vector3[] positions; //массив позиций 
    [SerializeField] private Vector3 dir; //количество позиций
    private int currentTarget; //текущая цель для передвижения



    public void FixedUpdate()
    {
        Moving();
    }
    
    //Проверка на столкновение с персонажем
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.TakeDamage(damageE);
        }
    }

    //ПЕРЕДВИЖЕНИЕ 
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
