using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Script : MonoBehaviour {

    public float timer;
    public float range;
    private bool possessed;
    private bool possessable;
    private Light possessionGlow;

    // On object creation, set possessable = true;
    void Start () {
        possessionGlow = GetComponent<Light>();
        possessionGlow.enabled = false;
        possessed = false;
        possessable = true;
	}

    // What does this entity do every frame?
    void Update () {
        if (possessed == true)
        {
            countDown();
        }
        else
        {
            // durr
        }
	}

    // Begins the timer, needs to be called on update while possessed
    void countDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            //player.returnControl
            endPossession();
        }
    }

    public void OnMouseDown()
    {
        GameObject pE = GameObject.FindGameObjectWithTag("Possessed");
        float distance = Vector2.Distance(gameObject.transform.position, pE.transform.position);
        if (distance < range)
        {
            beginPossession();
        }
    }

    public void beginPossession()
    {
        possessionGlow.enabled = true;
        possessed = true;
        gameObject.tag = ("Possessed");
    }

    public void endPossession()
    {
        gameObject.tag = ("Untagged");
    }
}