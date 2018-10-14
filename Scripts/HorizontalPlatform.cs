using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : Entity_Script {

    public Frog[] frogList;
    public float speed;
    public Transform platformCheck;
    public float ambientInterval;
    private float counterAmbient;
    private int direction = 1;
    private bool facingRight;

    // Use this for initialization
    void Start() {
        facingRight = true;
        Flip();
        
    }
    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.tag == "Possessed")
        {
            countDown();
            drawRange();
            checkFlip();
            interact();
        }
        else
        {
            counterAmbient += Time.deltaTime;
            if (counterAmbient >= ambientInterval)
            {
                direction = direction * -1;
                counterAmbient = 0;
                Flip();
            }
            transform.position += Vector3.left * speed * Time.deltaTime * direction;
            if (Physics2D.Linecast(player.transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform")))
            {
                player.transform.position += Vector3.left * speed * Time.deltaTime * direction;
            }
            foreach (Frog frog in frogList)
            {
                if (Physics2D.Linecast(frog.transform.position, frog.groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                {
                    frog.transform.position += Vector3.left * speed * Time.deltaTime * direction;
                }
            }
        }
    }

    void interact()
    {
        if (gameObject.tag == "Possessed")
        {
            float Dtime = Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * speed * Dtime;
                
                if (Physics2D.Linecast(player.transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                {
                    player.transform.position += Vector3.left * speed * Dtime;
                }
                foreach (Frog frog in frogList)
                {
                    if (Physics2D.Linecast(frog.transform.position, frog.groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                    {
                        frog.transform.position += Vector3.left * speed * Dtime;
                    }
                }
                
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * speed * Dtime;
                if (Physics2D.Linecast(player.transform.position, platformCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                {
                    player.transform.position += Vector3.right * speed * Dtime;
                }
                foreach (Frog frog in frogList)
                {
                    if (Physics2D.Linecast(frog.transform.position, frog.groundCheck.position, 1 << LayerMask.NameToLayer("Platform")))
                    {
                        frog.transform.position += Vector3.right * speed * Dtime;
                    }
                }
                
            }
        }
    }

    private void checkFlip()
    {
        float hMove = Input.GetAxis("Horizontal");
        if (hMove > .1 && !facingRight || hMove < -.1 && facingRight)
        {
            Flip();
        }
    }
}