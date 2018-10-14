﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Entity_Script {

    private Rigidbody2D rb;
    public Transform groundCheck;
    public float jumpSpeed;
    public float speed;
    private float counter;
    public float ambientInterval;
    private int direction = 1;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.tag == "Possessed")
        {
            countDown();
            drawRange();
            interact();
        }
        else
        {
            transform.position += Vector3.left * speed/3 * Time.deltaTime * direction;
            counter += Time.deltaTime;
            if (counter >= ambientInterval)
            {
                if (IsGrounded())
                {
                    Vector2 velocity = rb.velocity;
                    velocity = Vector2.up * jumpSpeed;
                    rb.velocity = velocity;
                }
                counter = 0;
                direction = direction * -1;
            }
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
        }
    }

    // Check if the frog is on the ground.
    private bool IsGrounded()
    {
        return Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")) ||
            Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Platform"));

    }
}
