using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public bool used = false;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (used)
        {
            Destroy(gameObject);
        }
    }
}