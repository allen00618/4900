using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public KeyCode attackKey;
    public float speed = 5f;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackKey) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = -firePoint.right * speed;
        }
    }
}