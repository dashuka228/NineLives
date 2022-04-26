using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    public int health = 9;
    public static PlayerInteraction Instance { get; set; }
    public string scene;

    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
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

    //переделать потом на другое 
    private void Die()
    {
        SceneManager.LoadScene(scene);
    }


}
