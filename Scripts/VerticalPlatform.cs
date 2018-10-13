﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : Entity_Script {

    public float speed;

    // Use this for initialization
    void Start()
    {

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
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * speed * Dtime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * speed * Dtime;
            }
        }
    }
}
