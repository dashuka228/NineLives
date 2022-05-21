using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] private float speed; //скорость

    [SerializeField] private Vector3[] positions; //массив позиций 
    private int currentTarget; //текущая цель для передвижения

    [SerializeField] private Transform dropTransform; //система координат для спавна объекта
    [SerializeField] private float timeToDrop; //через сколько секунд объекты будут выбрасываться
    [SerializeField] private GameObject objectt; //копия какого объекта будет падать
    private GameObject copyObject; //скопированный объект
    private bool timer = true; //таймер для спавна объекта

    private void Start()
    {
        copyObject = objectt;
    }

    private void Update()
    {
        if (timer)
        {
            Invoke("Drop", timeToDrop);
            timer = false;
        }
    }

    public void FixedUpdate()
    {
        Moving();
    }

    //ПЕРЕДВИЖЕНИЕ 
    private void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);
        if (transform.position == positions[currentTarget])
        {
            if (currentTarget < positions.Length - 1)
                currentTarget++;

            else
                currentTarget = 0;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    //ВЫБРОС ОБЪЕКТА
    private void Drop()
    {
        Instantiate(copyObject, dropTransform.transform.position, Quaternion.identity);
        timer = true;
    }
}
