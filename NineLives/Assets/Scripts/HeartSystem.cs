using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] private Image[] hearts;

    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;
    [SerializeField] private int lives, health;

    // Start is called before the first frame update
    void Start()
    {
        health = PlayerInteraction.Instance.health;
        lives = health;
    }


    // Update is called once per frame
    void Update()
    {
        health = PlayerInteraction.Instance.health;
        lives = health;

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
