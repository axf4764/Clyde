using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public float moveSpeed;
    public int lane;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(tag == "tomahawk")
        {
            transform.Rotate(Vector3.back * 400  * Time.deltaTime);
        }
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y, -6);
        if (transform.position.x > 11)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {        
        if(col.tag == "strong" || col.tag == "quick" || col.tag == "flying")
        {
            if (col.tag == "strong" && tag == "spear" || col.tag == "quick" && tag == "tomahawk" || col.tag == "flying" && tag == "arrow")
            {
                if(lane == col.GetComponent<GoogaMoova>().lane)
                col.GetComponent<GoogaMoova>().killGooga();
            }
            if (lane == col.GetComponent<GoogaMoova>().lane)
                Destroy(gameObject);
        }
        
    }
}
