using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMovement();
    }

    void DoMovement()
    {
        Vector2 moveVector = Vector2.zero;
        float speed = .015f;
        //basics
        if( Input.GetKey( KeyCode.W ) )
        {
            moveVector.y += speed;
        }
        if( Input.GetKey( KeyCode.A ) )
        {
            moveVector.x -= speed;
        }
        if( Input.GetKey( KeyCode.S ) )
        {
            moveVector.y -= speed;
        }
        if( Input.GetKey( KeyCode.D ) )
        {
            moveVector.x += speed;
        }
        if (moveVector!= Vector2.zero)
            moveVector = moveVector.normalized * speed;

        //hard coded stuff | makes the character smaller as he moves upward
        float yLimit = -.7f;
        transform.localScale = new Vector3(
            1.75f - Mathf.Abs( yLimit - this.transform.position.y ),
            1.75f - Mathf.Abs( yLimit - this.transform.position.y ),
            1.75f - Mathf.Abs( yLimit - this.transform.position.y )
            ); 

        body.MovePosition( new Vector2( transform.position.x + moveVector.x, transform.position.y + moveVector.y ) );

    }
}
