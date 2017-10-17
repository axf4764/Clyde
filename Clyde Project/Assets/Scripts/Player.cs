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

    public Sprite[] weaponStance = new Sprite[3];
    public int weapons;

    private Vector3 position;
    private Vector3 velocity;
    private Vector3 direction;
    private Vector3 acceleration;

    // These two attributes will prevent bullet rapid fire 
    private float fireDelay = 1.0f;
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
        if(fireTimer <= 0)
        {
            fireTimer = 0;
        }

        // 1 equips the bow
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[0];
            weapons = 1;
        }
        // 2 equips the spear
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[1];
            weapons = 2;
        }
        // 3 equips the hatchet
        if (Input.GetKey(KeyCode.Alpha3))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[2];
            weapons = 3;
        }

        if(Input.GetKey(KeyCode.Space) && fireTimer <= 0)
        {
            switch (weapons)
            {
                case 1:
                    Bow();
                    fireTimer = fireDelay;
                    break;

                case 2:
                    Spear();
                    fireTimer = fireDelay;
                    break;

                case 3:
                    Hatchet();
                    fireTimer = fireDelay;
                    break;

                default:
                    break;
            }
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
        if (collider.gameObject.tag.Equals("QuickGooga"))
        {
            manager.MinusLives();
            Debug.Log("I hit a QuickGooga");
        }
    }

}

