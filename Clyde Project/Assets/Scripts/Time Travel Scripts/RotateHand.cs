using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour 
{
	public GameObject hand1;
	public GameObject hand2;
	public GameObject hand3;
	public GameObject clockPart;

	private bool handIsTurning;
	private float currentTime;
	private float startTime;
	private float intervalTime = 2.0f;

	// Use this for initialization
	void Start () 
	{
		handIsTurning = true;
		startTime = Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		currentTime = Time.deltaTime;
		if ((currentTime - startTime) < intervalTime) 
		{
			// Rotate ();
		}
		float angle = Mathf.Atan2 (200, 0) * Mathf.Rad2Deg;

		hand1.transform.RotateAround (new Vector3(0, 0, 0), new Vector3 (0, 0, 10), -1.0f);
	}

	void Rotate()
	{
		
		for (int i = 0; i < 360; i++) 
		{
			float angle = Mathf.Atan2 (200, 0) * Mathf.Rad2Deg;
			hand1.transform.rotation = Quaternion.Euler (0, 0, angle);
		}

		// float angle = Mathf.Atan2 (200, 0);
		// hand1.transform.rotation = Quaternion.Euler (0, 0, angle + 180);
		
		/*
		Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		float angle = Mathf.Atan2 (mouseWorldPos.y, mouseWorldPos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0, 0, angle + 180);
		*/
	}


}
