using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : Entity_Script {

    public float speed;
    public float pickUpRange;
    private bool holding;

    // Use this for initialization
    void Start() {
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (possessed)
        {
            countDown();
            interact();
        }
    }

    void interact()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (holding)
            {
                player.transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (holding)
            {
                player.transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (holding)
            {
                player.transform.position += Vector3.up * speed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (holding)
            {
                player.transform.position += Vector3.down * speed * Time.deltaTime;
            }
        }

        float distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        if (distanceToPlayer < pickUpRange)
        {
            holding = true;
        }
        if (timer <= 0 || this != GameObject.FindGameObjectWithTag("Possessed"))
        {
            holding = false;
        }
    }
}
