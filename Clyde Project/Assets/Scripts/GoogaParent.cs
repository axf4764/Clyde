using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoogaParent : MonoBehaviour
{
    public int shotCheck;
    public Player killer = new Player();

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    bool CorrectShot(int checker)
    {
        if(checker == killer.shotType)
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
