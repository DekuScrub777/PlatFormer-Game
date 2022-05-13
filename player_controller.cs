using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    bool Onground = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider == true)
        {
            Debug.Log("on ground");
            anim.SetBool("Jumping", false);
            Onground = true;
        }
        

    }

    private void Update()
    {

        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(dirX = 6f, rb.velocity.y);
        }

        if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(dirX = -6f, rb.velocity.y);
        }

        if (Input.GetKey("space"))
        {
            if (Onground == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, 7f);
                Debug.Log("off ground");
                anim.SetBool("Jumping", true);
                Onground = false;   
            } 
            
        }

        Debug.Log(dirY);
     
       if (dirX > 0f) 
       {
            anim.SetBool("Running", true);
            spr.flipX = false;
        }
       else if (dirX < 0f) 
       {
            anim.SetBool("Running", true);
            spr.flipX = true;
       }
       else if (dirX == 0f) 
       {
            anim.SetBool("Running", false);
       }
    }
}
