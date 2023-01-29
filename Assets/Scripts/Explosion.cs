using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    public bool isActive;
    private float timer;
    public float timeBetweenFiring = 1f;
    private void Update()
    {

        if (!isActive)
        {

            Invoke("MakeBombFalse", 2f);
        }
        
           

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isActive = true;
            //GameManager.Instance.BigBoom();
            BoomWithTime();
        }
        
    }

    private void MakeBombFalse()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void BoomWithTime()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(Waiting());
        isActive = false;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
    }
}
