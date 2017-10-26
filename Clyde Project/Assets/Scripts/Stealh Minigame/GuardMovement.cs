using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovement : MonoBehaviour
{

    public Transform[] WayPoints;
    [SerializeField]
    private int index = 0;
    private Rigidbody2D body;
    private float speed = 1.5f;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Vector2.Distance(transform.position , WayPoints[index].position ) <.05f)
        {
            index = ( index + 1 ) % WayPoints.Length;
        }
        Vector3 moveVector = (( WayPoints[index].position - transform.position ).normalized * Time.deltaTime) * speed;

        body.MovePosition( new Vector2( transform.position.x + moveVector.x, transform.position.y + moveVector.y ) );

    }
}
