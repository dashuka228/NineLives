using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player; //�������������� ���������
    [SerializeField] private float moveUp; //�������� ������

    private Vector3 pos; //��������� ������


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
        pos.z = -20f; //�������� ������
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime); 
    }
}
