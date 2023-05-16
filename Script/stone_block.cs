using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stone_block : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isSolid = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isSolid && rb.velocity.y < 0f)
        {
            rb.velocity += new Vector2(Physics2D.gravity.x, Physics2D.gravity.y) * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isSolid && collision.gameObject.CompareTag("ground"))
        {
            isSolid = true;
            rb.isKinematic = true;
            GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}