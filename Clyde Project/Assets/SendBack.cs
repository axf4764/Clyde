using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendBack : MonoBehaviour {

    public GameObject Player;
    public Transform Respawn;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if(collision.tag == "Player")
        {
            Player.transform.position = Respawn.position;
        }

    }

}
