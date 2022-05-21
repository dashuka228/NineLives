using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //местоположение персонажа
    [SerializeField] private float moveUp; //поднятие камеры
    [SerializeField] private float speed; //скорость слежения

    private Vector3 pos; //положение камеры


    void Start()
    {
        if (!player)
            player = FindObjectOfType<Hero>().transform; 
    }


    void Update()
    {
        Tracking();
    }

    private void Tracking()
    {
        pos = player.position;
        pos.y += moveUp;
        pos.z = -20f; //фиксация камеры
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * speed); 
    }
}
