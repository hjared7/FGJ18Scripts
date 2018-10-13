using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    // Use this for initialization
    void Start () {
        timer = 5.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		// Intentionally blank
	}

    void interact()
    {
        if (Input.GetKey(KeyCode.W))
        {
            float hMove = Input.GetAxis("Horizontal");
            velocity.x = hMove * maxSpeed;
        }
    }
}
