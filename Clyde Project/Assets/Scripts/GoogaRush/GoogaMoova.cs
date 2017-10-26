using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoogaMoova : MonoBehaviour {
    public Sprite explodeSprite;
    private float moveSpeed;
    private float scaleExplosion;
    private bool exploding;
    public int lane;
    // Use this for initialization
    void Start()
    {
        if(tag == "quick")
        {
            moveSpeed = 3f * 1.5f;
        } else if (tag == "strong")
        {
            moveSpeed = 2f * 1.5f;
        } else if (tag == "flying")
        {
            moveSpeed = 2f * 1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -12  && !exploding)
        {
            killGooga();
        }

        if (!exploding)
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            if(tag == "flying")
            {
                if(transform.position.x <= -2.5f)
                {
                    gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
                }
            }
        } else
        {
            scaleExplosion += 0.1f;
            transform.localScale = new Vector3(scaleExplosion, scaleExplosion, scaleExplosion);
            if (tag == "quick")
            {
                if(scaleExplosion >= 1)
                {
                    Destroy(gameObject);
                }
            }
            else if (tag == "strong")
            {
                if (scaleExplosion >= 2)
                {
                    Destroy(gameObject);
                }
            }
            else if (tag == "flying")
            {
                if (scaleExplosion >= 1.5)
                {
                    Destroy(gameObject);
                }
            }
        }
        /*if (transform.position.y < -2 || huddy.stateTwoComplete)
        {
            Destroy(gameObject);
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!exploding)
        {
            if (col.tag == "log")
            {
                killGooga();
            }
        }
    }

    public void killGooga()
    {
        scaleExplosion = 0.1f;
        gameObject.GetComponent<SpriteRenderer>().sprite = explodeSprite;
        transform.localScale = new Vector3(scaleExplosion, scaleExplosion, scaleExplosion);
        exploding = true;        
        if (tag == "flying")
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>());
        }
    }

    public void SetLane(int l)
    {
        lane = l;
    }

    
}
