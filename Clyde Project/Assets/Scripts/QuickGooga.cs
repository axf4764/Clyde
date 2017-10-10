using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickGooga : GoogaParent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool IsDead()
    {
        shotCheck = 2;

        if (shotCheck == killer.shotType)
        {
            return true;
        }
        return false;
    }
}
