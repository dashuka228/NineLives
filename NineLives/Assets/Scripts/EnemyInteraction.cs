using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    private int health = 3;
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Character")
        {
            other.GetComponent<PlayerInteraction>().TakeDamage(damage);
        }
    }
}
