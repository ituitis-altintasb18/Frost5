using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    private float speed = 1.8f;
    private GameObject player;

    private AudioSource mAudioSrc;
    // Update is called once per frame
    private void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
        mAudioSrc.Play();
    }
    void Update()
    {
        player = GameObject.Find("Player");
        float step = speed * Time.deltaTime;
        
        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.AddLight();
            Destroy(gameObject);
            //it would be good to have particle effect here
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
