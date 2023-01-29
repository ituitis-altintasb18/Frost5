using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemyAI : MonoBehaviour
{
    private GameObject aliveVersion;
    private GameObject deadVersion;

    Collider2D zCollider;

    public bool ChaseCheck { get; private set; }

    private AudioSource AudioSrc;

    private void Start()
    {
        AudioSrc = GetComponent<AudioSource>();
        zCollider = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSrc.Play();

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            zCollider.enabled = !zCollider.enabled;

            Destroy(collision.gameObject);
            Destroy(gameObject, 2f);
        }
    }

}
