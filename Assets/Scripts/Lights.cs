using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    private bool pickUpAllowed;
    public GameObject lightSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && pickUpAllowed)
        {
            Instantiate(lightSource, transform.position, transform.rotation);
            gameObject.SetActive(false);
            //addlight was here
            Invoke("ActivationWithDelay", 5.0f);
        }
    }

    void ActivationWithDelay()
    {
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Trigger"))
        {
            pickUpAllowed = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Trigger"))
        {
            pickUpAllowed = false;
        }

    }
}
