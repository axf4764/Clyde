using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongGooga : GoogaParent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsDead()
    {
        shotCheck = 3;

        if (shotCheck == killer.shotType)
        {
            return true;
        }
        return false;
    }
}
