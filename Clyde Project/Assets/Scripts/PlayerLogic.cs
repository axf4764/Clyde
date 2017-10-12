using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin
public class PlayerLogic : MonoBehaviour
{
    public GameObject InteractNotification;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Tree" )
        {
            InteractNotification.SetActive( true );
        }
        else if( collision.gameObject.tag == "Exit")
        {

        }
    }
    private void OnTriggerExit2D( Collider2D collision )
    {
        if( InteractNotification.activeSelf )
        {
            InteractNotification.SetActive( false );
        }
    }
}
