using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("heh");
        if (other.CompareTag("AttackHitbox"))
        {
            Destroy(gameObject);
        }
    }
}
