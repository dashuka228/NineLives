using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCounter : MonoBehaviour
{
    [SerializeField] private Text itemsCounter; //блок текста

    void Update()
    {
        itemsCounter.text = "x" + PlayerInteraction.Instance.itemsInInventory.ToString(); //импорт items из player interaction
    }
}
