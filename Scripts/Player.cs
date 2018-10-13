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
        gameObject.tag = ("Player");
	}
	
	// Update is called once per frame
	void Update () {
        GameObject pE = GameObject.FindGameObjectWithTag("Possessed");
        if (pE)
        {
            possessingSomethingElse = false;
        }
        else
        {
            possessingSomethingElse = true;
        }
        possessionGlow.enabled = !possessingSomethingElse;
	}
}
