using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField] private int damageE = 1; //количество урона

    //Проверка на столкновение с персонажем
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.TakeDamage(damageE);
        }
    }
}
