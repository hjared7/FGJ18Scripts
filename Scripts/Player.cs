using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Light possessionGlow;
    public bool possessingSomethingElse;

	// Use this for initialization
	void Start () {
        possessingSomethingElse = false;
        possessionGlow = GetComponent<Light>();
        possessionGlow.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        ;
        if (GameObject.FindGameObjectWithTag("Possessed") != null)
        {
            possessingSomethingElse = true;
        }
        else
        {
            possessingSomethingElse = false;
        }
        possessionGlow.enabled = !possessingSomethingElse;
	}
}
