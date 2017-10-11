using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingGooga : GoogaParent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsDead()
    {
        shotCheck = 1;

        if (shotCheck == killer.shotType)
        {
            return true;
        }
        return false;
    }
}
