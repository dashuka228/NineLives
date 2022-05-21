using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke("DestroyObj", 1f);
    }

    private void DestroyObj()
    {
        Destroy(gameObject);
    }
}
