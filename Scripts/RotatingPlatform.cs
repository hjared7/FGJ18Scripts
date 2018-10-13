using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : Entity_Script {

    [SerializeField] float rotationSpeed;

	// Use this for initialization
	void Start () {
		timer = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
        // Intentionally blank;		
	}

    new void interact()
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
