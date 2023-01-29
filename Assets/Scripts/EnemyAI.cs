using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private GameObject aliveVersion;
    private GameObject deadVersion;

    Collider2D zCollider;

    private GameObject player;
    public float speed;

    public bool ChaseCheck { get; private set; }

    private AudioSource nAudioSrc;

    private void Start()
    {
        nAudioSrc = GetComponent<AudioSource>();
        zCollider = GetComponent<Collider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //playerin yeri bulundu
        player = GameObject.Find("Player");
        float step = speed * Time.deltaTime;

        //zombie checks player scriptinde goz gibi calisan kod playeri gordu
        ChaseCheck = transform.GetChild(1).GetComponent<ZombieChecksPlayer>().isChasing;
        

        //eger karakteri gorduysek ona dogru yuruduk
        if (ChaseCheck)
        {
            // move sprite towards the target location
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            nAudioSrc.Play();

            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);

            zCollider.enabled = !zCollider.enabled;

            Destroy(collision.gameObject);
            speed = 0;
            Destroy(gameObject,2f);
        }
    }

}
