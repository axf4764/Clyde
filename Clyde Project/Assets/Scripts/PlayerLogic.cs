using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin
public class PlayerLogic : MonoBehaviour
{
    public GameObject InteractNotification;
    public enum PlayerState
    {
        Default,
        Dialogue
    }

    private PlayerState currentState = PlayerState.Default;

    public PlayerState CurrentState
    {
        get { return  this.currentState; }
        set { this.currentState = value; }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var playerVar = gameObject.GetComponent<PlayerMovement>();
        if( currentState == PlayerState.Default)
        { 
            playerVar.DoMovement();
        }
        else if( currentState == PlayerState.Dialogue )
        {

        }
    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Interactable" )
        {
            InteractNotification.SetActive( true );
        }
        //else if( collision.gameObject.tag == "Exit")
        //{

        //}
    }
    private void OnTriggerExit2D( Collider2D collision )
    {
        if( InteractNotification.activeSelf )
        {
            InteractNotification.SetActive( false );
        }
    }
}
