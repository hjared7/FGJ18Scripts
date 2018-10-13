using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Entity_Script {

    private Rigidbody2D rb;
    public Transform groundCheck;
    public float jumpSpeed;
    public float speed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.tag == "Possessed")
        {
            countDown();
            interact();
        }
    }

    void interact()
    { 
        if (gameObject.tag == "Possessed")
        {
            float Dtime = Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Dtime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Dtime;
            }
            Vector2 velocity = rb.velocity;
            if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
            {
                velocity = Vector2.up * jumpSpeed;
                rb.velocity = velocity;
            }
            Debug.Log(IsGrounded());
        }
    }

    // Check if the frog is on the ground.
    private bool IsGrounded()
    {
        return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
