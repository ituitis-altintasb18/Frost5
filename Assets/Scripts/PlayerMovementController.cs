using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMove
{
    [SerializeField]
    private float moveSpeed = 10;

    public float SpeedX { get; private set; }
    public float SpeedY { get; private set; }

    

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        SpeedX = horizontal;
        float vertical = Input.GetAxis("Vertical");
        SpeedX = vertical;

        Vector3 movement = new Vector3(horizontal, vertical);

        transform.position += movement * Time.deltaTime * moveSpeed;

    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("End"))
        {
            GameManager.Instance.GameWin();
        }
    }
}
