using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : Entity_Script {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Possessed")
        {
            countDown();
            interact();
        }
	}

    void interact()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed, Space.World);
        }
    }
}
