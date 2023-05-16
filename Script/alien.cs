using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien : MonoBehaviour
{
    public int maxLife = 10;
    public float bulletSpeed = 25f;
    public GameObject bulletPrefab;
    public float shootRate = 3f;
    private float nextShootTime = 0f;
    private int currentLife;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShootTime)
        {
            nextShootTime = Time.time + shootRate;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = transform.right * bulletSpeed;
        Destroy(bullet, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(1);
        }
    }

    void TakeDamage(int damage)
    {
        currentLife -= damage;
        if(currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}