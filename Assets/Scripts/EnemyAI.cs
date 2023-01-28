using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject player;
    public float speed;

    public bool ChaseCheck { get; private set; }

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
}
