using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Script
/// This script is to be attached to the Player 
/// A script that...
/// </summary>
/// 
public class Player : MonoBehaviour {

    // Types of weaponry
    public int shotType;
    public GameObject bow;
    public GameObject spear;
    public GameObject hatchet;

    private Vector3 position;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 acceleration;

    // These two attributes will prevent bullet rapid fire 
    private float fireDelay;
    private float fireTimer;

    private SceneManager manager;

    // Use this for initialization
    void Start ()
    {
        GameObject sceneManagerObj = GameObject.FindWithTag("GameController");
        manager = sceneManagerObj.GetComponent<SceneManager>();

        position = new Vector3(0, 0, 0);
        velocity = new Vector3(0, 0, 0);
        direction = new Vector3(0, 1, 0);
        acceleration = new Vector3(0, 0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        fireTimer -= Time.deltaTime;

        // Q throws arrow from bow
        if (Input.GetKey(KeyCode.Q) && fireTimer <= 0) {
            Bow();
            fireTimer = fireDelay;
        }
        // E throws spear
        if (Input.GetKey(KeyCode.E) && fireTimer <= 0) {
            Spear();
            fireTimer = fireDelay;
        }
        // A throws hatchet
        if (Input.GetKey(KeyCode.A) && fireTimer <= 0) {
            Hatchet();
            fireTimer = fireDelay;
        }
    }

    void Bow()
    {
        // Spawn an arrow from bow
        Instantiate(bow, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void Spear()
    {
        Instantiate(spear, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void Hatchet()
    {
        Instantiate(hatchet, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("QuickGooba"))
        {
            manager.MinusLives();
            Debug.Log("I hit a QuickGooga");
        }
    }

}

