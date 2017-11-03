using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour 
{
	public GameObject hand1;
	public GameObject hand2;
	public GameObject hand3;

	public GameObject clockPart1;
	public GameObject clockPart2;
	public GameObject clockPart3;
	public GameObject clockPart4;

	public GameObject currentHand;
	public GameObject currentPart;

	public List<GameObject> handList;
	public List<GameObject> partList;

	// public GameObject[] handArray = new GameObject[3];
	// public GameObject[] clockPartArray = new GameObject[4];

	private int randNumHand;
	private int randNumPart;

	private int partRange = 4;
	private int handRange = 3;

	private bool handIsTurning;
	private float currentTime;
	private float startTime;
	private float intervalTime = 2.0f;

	// Use this for initialization
	void Start () 
	{
		handList.Add (hand1);
		handList.Add (hand2);
		handList.Add (hand3);

		partList.Add (clockPart1);
		partList.Add (clockPart2);
		partList.Add (clockPart3);
		partList.Add (clockPart4);

		handIsTurning = true;
		startTime = Time.deltaTime;

		randNumPart = Random.Range (0, partRange);
		randNumHand = Random.Range (0, handRange);

		currentHand = handList [randNumHand];

		currentPart = partList [randNumPart];
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

		if (handList.Count != 0) 
		{
			currentHand.transform.RotateAround (new Vector3 (0, 0, 0), new Vector3 (0, 0, 10), -1.0f);
		}

		if (Input.GetKeyDown ("space") && (currentPart.GetComponent<HandCollide>().isColliding == true)) 
		{
			currentPart.GetComponent<SpriteRenderer> ().color = Color.blue;

			if (handList.Count > 0) 
			{
				handList.Remove (currentHand);
			} 

			if(partList.Count > 0)
			{
				partList.Remove (currentPart);
			}

			handRange--;
			partRange--;

			randNumPart = Random.Range (0, partRange);
			randNumHand = Random.Range (0, handRange);

			currentHand = handList [randNumHand];
			currentPart = partList [randNumPart];
		}
	}

	void Rotate()
	{
		
		for (int i = 0; i < 360; i++) 
		{
			float angle = Mathf.Atan2 (200, 0) * Mathf.Rad2Deg;
			if (handList.Count != 0) 
			{
				currentHand.transform.rotation = Quaternion.Euler (0, 0, angle);
			}
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
