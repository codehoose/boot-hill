using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDetection : MonoBehaviour
{
    public string enemyTank = "RightTank";

    public event EventHandler BulletHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTank)
        {
            BulletHit?.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}
