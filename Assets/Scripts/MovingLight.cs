using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    private float speed = 15.0f;
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        float step = speed * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

}
