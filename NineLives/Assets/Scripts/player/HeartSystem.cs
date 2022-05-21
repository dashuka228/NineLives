using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{

    [SerializeField] private Image[] hearts; //������ ������

    [SerializeField] private Sprite aliveHeart; //������ ������ ������
    [SerializeField] private Sprite deadHeart; //������ �������� ������

    private int lives; //���������� ������
    private int health; //���������� ������


    void Update()
    {
        health = PlayerInteraction.Instance.health;
        lives = health;

        HeartsSystem();
    }

    //������� ������
    private void HeartsSystem()
    {
        if (health > lives)
            health = lives;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;
            else
                hearts[i].sprite = deadHeart;

            if (i < lives)
                hearts[i].enabled = true;
            else
                hearts[i].enabled = false;
        }
    }
}
