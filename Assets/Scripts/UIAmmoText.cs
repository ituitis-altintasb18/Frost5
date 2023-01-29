using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmoText : MonoBehaviour
{
    private Text textForAmmo;
    private int ammoCount = 0;

    private void Awake()
    {
        textForAmmo = GetComponent<Text>();
    }
    private void Start()
    {
        ammoCount = ammoCount - 1;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = GameObject.Find("RotatePoint").GetComponent<Shooting>().ammo + 1;
        textForAmmo.text = ammoCount.ToString();
    }
}
