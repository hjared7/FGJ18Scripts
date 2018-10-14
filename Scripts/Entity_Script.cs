using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity_Script : MonoBehaviour {

    public Player player;
    public LineRenderer lineRend;
    public AudioSource soundPlayer;

    public float timer;
    public float range;

    public int vertexCount = 40;
    public float lineWidth = 0.1f;



    void Start() {
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
        if (distancePlayer < player.range || distancePE < range)
        {
            if (pE != null)
            {
                pE.gameObject.tag = "Untagged";
                pE.GetComponent<LineRenderer>().enabled = false;
            }
            beginPossession();
        }
    }

    private void beginPossession()
    {
        soundPlayer.Play();
        AudioSource playerSound = player.GetComponent<AudioSource>();
        playerSound.Play();
        gameObject.tag = ("Possessed");
        lineRend.enabled = true;
    }

    private void endPossession()
    {
        gameObject.tag = ("Untagged");
        lineRend.enabled = false;
    }

    public void drawRange()
    {
        lineRend.widthMultiplier = lineWidth;
        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0.0f;
        lineRend.positionCount = vertexCount;
        for (int i = 0; i < lineRend.positionCount; i++)
        {
            Vector2 pos = new Vector2(range * Mathf.Cos(theta) + transform.position.x,
                range * Mathf.Sin(theta) + transform.position.y);
            lineRend.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
}