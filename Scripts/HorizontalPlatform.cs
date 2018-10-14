﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : Entity_Script {

    public Frog[] frogList;
    public float speed;
    public Transform platformCheck;
    public float ambientInterval;
    private float counter;
    private int direction = 1;

    // Use this for initialization
    void Start() {

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
            counter += Time.deltaTime;
            transform.position += Vector3.left * speed * Time.deltaTime * direction;
            if (counter >= ambientInterval / 2)
            {
                direction = direction * -1;
                counter = 0;
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
                if (Physics2D.Linecast(player.transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                {
                    player.transform.position += Vector3.left * speed * Dtime;
                }
                foreach (Frog frog in frogList)
                {
                    if (Physics2D.Linecast(frog.transform.position, frog.groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                    {
                        frog.transform.position += Vector3.left * speed * Dtime;
                    }
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Dtime;
                if (Physics2D.Linecast(player.transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                {
                    player.transform.position += Vector3.right * speed * Dtime;
                }
                foreach (Frog frog in frogList)
                {
                    if (Physics2D.Linecast(frog.transform.position, frog.groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                    {
                        frog.transform.position += Vector3.right * speed * Dtime;
                    }
                }
                
            }
        }
    }
}
