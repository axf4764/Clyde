using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugLines : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //void OnTriggerStay( Collision collision )
    //{
    //    foreach( ContactPoint contact in collision.contacts )
    //    {
    //        //print( contact.thisCollider.name + " hit " + contact.otherCollider.name );
    //        Debug.DrawRay( contact.point, contact.normal, Color.white );
    //    }
    //}
    private void OnTriggerStay2D( Collider2D collision )
    {

        //foreach( ContactPoint2D contact in  )
        //{
        //    //print( contact.thisCollider.name + " hit " + contact.otherCollider.name );
        //    Debug.DrawRay( contact.point, contact.normal, Color.white );
        //}
    }
}
