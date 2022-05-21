using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    //ГЕЙМПЛЕЙ
    [SerializeField] public int health = 9; //здоровье
    [SerializeField] public int damage = 1; //урон
    [SerializeField] private int invincibleTime = 5; //время неуязвимости после принятия урона

    private bool invincible = false;

    //СЦЕНА
    private string scene; 

    //ITEMS
    public int itemsInInventory = 0; //количество предметов в инвентаре

    //СОЗДАНИЕ ССЫЛКИ К СКРИПТУ
    public static PlayerInteraction Instance { get; set; }


    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        Instance = this;
    }


    //ПРИНЯТИЕ УРОНА
    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            health -= damage;
            invincible = true;
            Invoke("resetInvulnerability", invincibleTime);
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

    //ДОБАВЛЕНИЕ ITEMS
    public void AddItem(int itemCount)
    {
        itemsInInventory += itemCount;
        Debug.Log("УРА, в инвентаре:" + itemsInInventory);
    }

    //СМЕРТЬ(((
    private void Die()
    {
        SceneManager.LoadScene(scene);
    }


}
