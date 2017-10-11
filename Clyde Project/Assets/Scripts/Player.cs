using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Types of weaponry
    public GameObject bow;
    public GameObject spear;
    public GameObject hatchet;

    private Vector3 position;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 acceleration;

    // These two attributes  will prevent bullet rapid fire 
    private float fireDelay;
    private float fireTimer;

    // Use this for initialization
    void Start () {
        GameObject sceneManagerObj = GameObject.FindWithTag("GameController");

        position = new Vector3(0, 0, 0);
        velocity = new Vector3(0, 0, 0);
        direction = new Vector3(0, 1, 0);
        acceleration = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        fireTimer -= Time.deltaTime;
    }
}
