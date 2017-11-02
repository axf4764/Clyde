using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWoodCatching : MonoBehaviour {
    public float movePos = 0.05f;
    private bool movingRight = false;
    public HUD huddy;
    // Use this for initialization
    void Start()
    {
        huddy = GameObject.FindGameObjectWithTag("manager").GetComponent<HUD>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > -1.7)
        {
            transform.position = new Vector3(transform.position.x - movePos * Time.deltaTime, transform.position.y, 0);
            if (!movingRight)
            {
                movingRight = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 1.7)
        {
            transform.position = new Vector3((transform.position.x + movePos * Time.deltaTime), transform.position.y, 0);
            if (movingRight)
            {
                movingRight = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        huddy.Wood ++;
        Destroy(col.gameObject);
    }
}
