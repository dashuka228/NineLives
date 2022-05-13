using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    //��������
    [SerializeField] public int health = 9; //��������
    [SerializeField] public int damage = 1; //����
    [SerializeField] private int invincibleTime = 5; //����� ������������ ����� �������� �����

    private bool invincible = false;

    //�����
    private string scene; 

    //ITEMS
    private int itemsInInventory = 0; //���������� ��������� � ���������

    //�������� ������ � �������
    public static PlayerInteraction Instance { get; set; }


    void Start()
    {
        scene = SceneManager.GetActiveScene().name;
        Instance = this;
    }

    //�������� �����
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

    //���������� ITEMS
    public void AddItem(int itemCount)
    {
        itemsInInventory += itemCount;
        Debug.Log("���, � ���������:" + itemsInInventory);
    }

    //������(((
    private void Die()
    {
        SceneManager.LoadScene(scene);
    }


}
