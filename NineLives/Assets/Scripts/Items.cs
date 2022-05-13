using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    //Проверка на столкновение с врагом
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "hero")
        {
            PlayerInteraction.Instance.AddItem(1);
            Destroy(this.gameObject);
        }
    }
}
