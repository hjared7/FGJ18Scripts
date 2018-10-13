using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Script : MonoBehaviour {

    public GameObject player = GameObject.FindGameObjectWithTag("Player");
    public float timer;
    public float range;
    public bool possessed;
    private bool possessable;
    private Light possessionGlow;

    // On object creation, set possessable = true;
    void Start () {
        possessionGlow = GetComponent<Light>();
        possessionGlow.enabled = false;
        possessed = false;
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
        float distance = Vector2.Distance(gameObject.transform.position, pE.transform.position);
        if (distance < range)
        {
            beginPossession();
        }
    }

    private void beginPossession()
    {
        possessionGlow.enabled = true;
        possessed = true;
        possessable = false;
        gameObject.tag = ("Possessed");
    }

    private void endPossession()
    {
        gameObject.tag = ("Untagged");
        possessed = false;
    }
}