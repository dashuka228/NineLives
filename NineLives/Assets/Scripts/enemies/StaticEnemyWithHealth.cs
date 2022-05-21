using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemyWithHealth : MonoBehaviour
{

    [SerializeField] private int health = 3; //здоровье 
    [SerializeField] private int damageE = 1; //урон


    //¬раг наносит урон
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.TakeDamage(damageE);
        }
    }

    //¬раг принимает урон
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "hero")
        {
            TakeDamageE(PlayerInteraction.Instance.damage);
            Debug.Log("Ўмоне пиздец");
        }
    }

    //ѕ–»Ќя“»≈ ”–ќЌј
    private void TakeDamageE(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    //—ћ≈–“№
    private void Die()
    {
        Destroy(this.gameObject);
    }
}
