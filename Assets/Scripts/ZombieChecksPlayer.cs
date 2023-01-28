using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieChecksPlayer : MonoBehaviour
{
    public bool isChasing;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Trigger"))
        {
            isChasing = true;
        }
    }
}
