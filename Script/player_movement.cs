using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed = 3f , jumpForce = 8f;
    private Rigidbody2D rb;
    public KeyCode leftKey, rightKey, jumpKey;
    private bool isFacingRight = true;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = 0f;

        if(Input.GetKey(leftKey))
        {
            horizontalMovement = -1f;
        }
        else if(Input.GetKey(rightKey))
        {
            horizontalMovement = 1f;
        }
        
        rb.velocity = new Vector2(horizontalMovement * speed, rb.velocity.y);

        if(horizontalMovement<0 && !isFacingRight)
        {
            Flip();
        }
        else if(horizontalMovement>0 && isFacingRight)
        {
            Flip();
        }

        if(Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Flip()
	{
		transform.Rotate(0, 180, 0);
		isFacingRight = !isFacingRight; 
	}

    void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("ground")) 
        {
            isGrounded = true;
        }    
	}

    void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("ground")) 
        {
            isGrounded = false;
        }    
	}
}