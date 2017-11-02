using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollide : MonoBehaviour 
{
	public Material mat;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		// OnCollisionEnter (gameObject.GetComponent<CircleCollider2D>());
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Test") 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Test") 
		{
			gameObject.GetComponent<SpriteRenderer> ().color = Color.white;
		}
	}
}