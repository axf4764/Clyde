using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Player Script
/// This script is to be attached to the Player 
/// A script that...
/// </summary>
/// 
public class Player : MonoBehaviour {

    // Types of weaponry
    public GameObject bow;
    public GameObject spear;
    public GameObject hatchet;
    private GameObject weaponClone;
    public Vector3[] lanes = new Vector3[4];
    private int lane;
    public Sprite[] weaponStance = new Sprite[3];
    public Sprite[] weaponRest = new Sprite[3];
    public RawImage[] iconSelector = new RawImage[3];
    public GameObject[] laneHighlighter = new GameObject[3];
    //public Vector3[] iconPos = new Vector3[3];
    public int weapons;

    // These two attributes will prevent bullet rapid fire 
    private float fireDelay = 1.0f;
    private float fireTimer;

    // Use this for initialization
    void Start ()
    {
        lane = 0;
        transform.position = lanes[0];
        weapons = 3;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 1 equips the bow
        if (Input.GetKeyDown(KeyCode.UpArrow) && lane < 3)
        {
            lane++;
            transform.position = lanes[lane];
            laneHighlighter[0].GetComponent<SpriteRenderer>().enabled = false;
            laneHighlighter[1].GetComponent<SpriteRenderer>().enabled = false;
            laneHighlighter[2].GetComponent<SpriteRenderer>().enabled = false;
            if (lane != 3)
            {
                laneHighlighter[lane].GetComponent<SpriteRenderer>().enabled = true;
            }
            
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && lane > 0)
        {
            lane--;
            transform.position = lanes[lane];
            laneHighlighter[0].GetComponent<SpriteRenderer>().enabled = false;
            laneHighlighter[1].GetComponent<SpriteRenderer>().enabled = false;
            laneHighlighter[2].GetComponent<SpriteRenderer>().enabled = false;
            laneHighlighter[lane].GetComponent<SpriteRenderer>().enabled = true;
        }
        if (fireTimer > 0)
        {
            fireTimer -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponRest[weapons - 1];
            if (fireTimer <= 0)
            {
                fireTimer = 0;
                gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[weapons - 1];
            }
        }


        // 1 equips the bow
        if (Input.GetKey(KeyCode.Alpha3))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[0];

            iconSelector[0].GetComponent<RawImage>().enabled = true;
            iconSelector[1].GetComponent<RawImage>().enabled = false;
            iconSelector[2].GetComponent<RawImage>().enabled = false;
            weapons = 1;
            if (fireTimer > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = weaponRest[weapons - 1];
            }
        }
        // 2 equips the spear
        if (Input.GetKey(KeyCode.Alpha2))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[1];
            iconSelector[0].GetComponent<RawImage>().enabled = false;
            iconSelector[1].GetComponent<RawImage>().enabled = true;
            iconSelector[2].GetComponent<RawImage>().enabled = false;
            weapons = 2;
            if (fireTimer > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = weaponRest[weapons - 1];
            }
        }
        // 3 equips the hatchet
        if (Input.GetKey(KeyCode.Alpha1))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = weaponStance[2];
            iconSelector[0].GetComponent<RawImage>().enabled = false;
            iconSelector[1].GetComponent<RawImage>().enabled = false;
            iconSelector[2].GetComponent<RawImage>().enabled = true;
            weapons = 3;
            if (fireTimer > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = weaponRest[weapons - 1];
            }
        }


        if (Input.GetKey(KeyCode.Space) && fireTimer <= 0)
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
        weaponClone = Instantiate(bow, new Vector3(transform.position.x, transform.position.y, -6), transform.rotation);
        weaponClone.GetComponent<Weapon>().lane = lane + 1;
    }

    void Spear()
    {
        weaponClone = Instantiate(spear, new Vector3(transform.position.x, transform.position.y + 0.7f, -6), transform.rotation);
        weaponClone.GetComponent<Weapon>().lane = lane + 1;
    }

    void Hatchet()
    {
        weaponClone = Instantiate(hatchet, new Vector3(transform.position.x, transform.position.y + 0.7f, -6), transform.rotation);
        weaponClone.GetComponent<Weapon>().lane = lane + 1;
    }

}

