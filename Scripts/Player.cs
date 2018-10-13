using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity_Script {

	// Use this for initialization
	void Start () {
        timer = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /* Overrides Entity's countDown method so that the player
    can always be possessable */
    void countDown()
    {
        // Intentionally does nothing
    }
}
