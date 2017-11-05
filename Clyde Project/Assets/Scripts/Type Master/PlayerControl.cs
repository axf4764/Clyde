using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private GameController manager;


    // Use this for initialization
    void Start ()
    {
        GameObject managerObj = GameObject.FindWithTag("GameController");
        manager = managerObj.GetComponent<GameController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag.Equals("missile"))
        {
            manager.MinusLives();
            Debug.Log("minus health");
        }
    }
}
