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
                if (holding)
                {
                    player.transform.position += Vector3.left * speed * Dtime;
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Dtime;
                if (holding)
                {
                    player.transform.position += Vector3.right * speed * Dtime;
                }
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Dtime;
                if (holding)
                {
                    player.transform.position += Vector3.up * speed * Dtime;
                }
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Dtime;
                if (holding)
                {
                    player.transform.position += Vector3.down * speed * Dtime;
                }
            }

            float distanceToPlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
            Debug.Log(distanceToPlayer);
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
}
