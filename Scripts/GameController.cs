using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField] Player player;
    Entity possessed;
    Entity[] nonPossessable;

	// Use this for initialization
	void Start () {
        possessed = player;
        nonPossessable = new Entity[100];
	}
	
	// Update is called once per frame
	void Update () {
        // Unpossess an item if its time runs out
		if (possessed.countDown() <= 0)
        {
            possessed = player;
        }
        // Update the possessed object on a left-mouse click
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform && hit.transform.gameObject.GetType().Equals(possessed.gameObject.GetType()))
                { 
                    Entity ClickedItem = hit.transform.gameObject;
                    bool inList = false;
                    // If the clicked item is not in nonPossessable (Possessable), possess it
                    for (int i = 0; i < nonPossessable.Length; i++)
                    {
                        if (nonPossessable[i] == ClickedItem)
                        {
                            inList = true;
                        }
                    }
                    if (!inList)
                    {   
                        nonPossessable[nonPossessable.Length] = possessed;
                        possessed = ClickedItem;
                    }
                }
            }
        }
        // Perform the possessed object's actions
        possessed.Interact();
    }
}