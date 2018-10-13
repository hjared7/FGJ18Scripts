using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public GameObject goal;
    public float goalDistance;
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
        if (GameObject.FindGameObjectWithTag("Possessed") != null)
        {
            possessingSomethingElse = true;
        }
        else
        {
            possessingSomethingElse = false;
        }
        possessionGlow.enabled = !possessingSomethingElse;
        if (goalDistance < Vector2.Distance(goal.transform.position, gameObject.transform.position))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
