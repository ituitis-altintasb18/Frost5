using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmoText : MonoBehaviour
{
    private Text textForAmmo;
    private int ammoCount;

    private void Awake()
    {
        textForAmmo = GetComponent<Text>();
    }
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoCount = GameObject.Find("RotatePoint").GetComponent<Shooting>().ammo;
        textForAmmo.text = ammoCount.ToString();
    }
}
