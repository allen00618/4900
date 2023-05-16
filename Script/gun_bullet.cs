using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_bullet : MonoBehaviour
{
    public float speed = 25f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Destroy(gameObject);
        }
    }
}
