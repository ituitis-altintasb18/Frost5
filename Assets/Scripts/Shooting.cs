using UnityEngine;
//using UnityEngine.Experimental.Rendering.Universal;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    private int ammo;

    //public Light2D light2D;

    private AudioSource mAudioSrc;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mAudioSrc = GetComponent<AudioSource>();
        //light2D = GameObject.Find("FlashLight").GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        //game manager i update de cagirmak ne kadar dogruydu bilmiyorum
        //bu light sayisini game manager dan aliyo almadan once game manager sayiyi tabii ammo cinsinden (x3) cinsinden veriyo
        ammo = GameManager.Instance.lights;

        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if((timer >= timeBetweenFiring) && (ammo != 0))
            {
                canFire = true;
                timer = 0;
                GameManager.Instance.RemoveLight();
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            mAudioSrc.Play();
            //light2D.enabled = true;
            //light2D.enabled = false;

            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);            
        }
    } 
}
