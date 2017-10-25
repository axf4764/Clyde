using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour {
    public float fallSpeed = 0.075f;
    private HUD huddy;
    // Use this for initialization
    void Start () {
        huddy = GameObject.FindGameObjectWithTag("manager").GetComponent<HUD>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, (transform.position.y - fallSpeed * Time.deltaTime) , transform.position.z);

        if(transform.position.y < -2 || huddy.stateTwoComplete)
        {
            Destroy(gameObject);
        }
    }
}
