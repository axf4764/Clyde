using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Rigidbody2D ) )]
public class GuardMovement : MonoBehaviour
{

    public Transform[] WayPoints;
    [SerializeField]
    private int index = 0;
    private Rigidbody2D body;
    private float moveSpeed = 0.7f;
    private float rotationSpeed = 0.05f;
    private GuardState guardState = GuardState.Patrolling;
    private float idleTimer = 0.0f;


    public enum GuardState
    {
        //Patrol if player not seen by moving between waypoints
        Patrolling,
        //Deviate from patrol path if suspicious of player
        //IE moving between points closer to the player or distraction for a small time
        Searching,
        //Chase player if detected by flashlight hitbox
        //Move slightly faster than player can, move 
        //either directly toward player, or where it predicts the player will be in a second
        Chasing,
        Idle
    }


    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        idleTimer += Time.deltaTime;
        
        #region Guard Position
        //Go to the next waypoint, looping
        if( Vector2.Distance( transform.position, WayPoints[ index ].position ) < .05f )
        {
            index = ( index + 1 ) % WayPoints.Length;
            guardState = GuardState.Idle;
            idleTimer = 0.0f;
        }

        if( idleTimer > 1.0f )
        {
            guardState = GuardState.Patrolling;
        }

        if( guardState == GuardState.Patrolling )
        {
            Vector3 moveVector = ( ( WayPoints[index].position - transform.position ).normalized * Time.deltaTime ) * moveSpeed;
            body.MovePosition( new Vector2( transform.position.x + moveVector.x, transform.position.y + moveVector.y ) );

            float angle = Mathf.Atan2(moveVector.y,moveVector.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.AngleAxis( angle, Vector3.forward ), rotationSpeed );
        }
        #endregion
    }
}
