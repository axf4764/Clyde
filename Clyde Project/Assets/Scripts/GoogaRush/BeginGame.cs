using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<GoogaManager>().enabled = true;
            Destroy(gameObject);
        }
	}
}
