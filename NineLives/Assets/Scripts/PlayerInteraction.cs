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

    private void Update()
    {
        
    }

    //private bool invincible = false;
    //public float invincibilityTime = 3f;

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (!invincible)
    //    {
    //        if (collision.gameObject.tag == "enemy")
    //        {
    //            StartCoroutine(Invulnerability());
    //        }
    //    }
    //}

    //IEnumerator Invulnerability()
    //{
    //    invincible = true;
    //    yield return new WaitForSeconds(invincibilityTime);
    //    invincible = false;
    //}


    private bool invincible = false;

    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage;
            invincible = true;
            Invoke("resetInvulnerability", 5);
        }

        if (health <= 0)
        {
            Die();
        }
    }
    void resetInvulnerability()
    {
        invincible = false;
    }

    //переделать потом на другое 
    private void Die()
    {
        SceneManager.LoadScene(scene);
    }


}
