using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float goalDistance;
    public GameObject goal;

    public LineRenderer lineRend;
    public float lineWidth = .1f;
    public int vertexCount = 40;
    public float range = 2.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        drawRange();
        if (goalDistance > Vector2.Distance(goal.transform.position, gameObject.transform.position))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    private void drawRange()
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
