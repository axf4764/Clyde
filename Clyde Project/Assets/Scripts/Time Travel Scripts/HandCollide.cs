using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollide : MonoBehaviour 
{
	public bool isColliding;
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
		if (col.gameObject.tag == "Test" && (GameObject.FindGameObjectWithTag("Clock").GetComponent<RotateHand>().currentHand == col.gameObject) && (gameObject == GameObject.FindGameObjectWithTag("Clock").GetComponent<RotateHand>().currentPart)) 
		{
			GameObject.FindGameObjectWithTag("Clock").GetComponent<RotateHand>().currentPart.GetComponent<SpriteRenderer> ().color = Color.red;
			isColliding = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Test") 
		{
			GameObject.FindGameObjectWithTag("Clock").GetComponent<RotateHand>().currentPart.GetComponent<SpriteRenderer> ().color = Color.white;
			isColliding = false;
		}
	}
}