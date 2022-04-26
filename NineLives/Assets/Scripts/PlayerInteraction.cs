using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public int health = 9;
    public static PlayerInteraction Instance { get; set; }

    void Start()
    {
        Instance = this;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }


}
