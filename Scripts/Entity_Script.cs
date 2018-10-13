﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Script : MonoBehaviour {

    public GameObject player;
    public float timer;
    public float range;
    private bool possessable;
    public Light possessionGlow;


    // On object creation, set possessable = true;
    void Start() {
        possessable = true;
    }

    // Begins the timer, needs to be called on update while possessed
    public void countDown()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            endPossession();
        }
    }

    public void OnMouseDown()
    {
        GameObject pE = GameObject.FindGameObjectWithTag("Possessed");
        float distancePlayer = Vector2.Distance(player.transform.position, gameObject.transform.position);
        float distancePE;
        if (pE != null) {
            distancePE = Vector2.Distance(gameObject.transform.position, pE.transform.position);
        }
        else
        {
            distancePE = 10000000000;
        }
        if (distancePlayer < range || distancePE < range)
        {
            if (pE != null)
            {
                pE.gameObject.tag = "Untagged";
                pE.GetComponent<Light>().enabled = false;
            }
            beginPossession();
        }
    }

    private void beginPossession()
    {
        possessionGlow.enabled = true;
        possessable = false;
        gameObject.tag = ("Possessed");
    }

    private void endPossession()
    {
        gameObject.tag = ("Untagged");
        possessionGlow.enabled = false;
    }
}