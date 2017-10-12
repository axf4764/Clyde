using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodManager : MonoBehaviour {

    //Prefabs for the bullet and its clone
    public GameObject log;
    private GameObject logClone;
    private float spawnTimer = 0;
    private float timer = 0;
    //Reference to the scene manager
    private HUD huddy;

    // Use this for initialization
    void Start()
    {
        huddy = GameObject.FindGameObjectWithTag("manager").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (huddy.stateTwo)
        {
            timer -= Time.deltaTime;
            //Checks to see if spacebar was pressed
            if (timer < 0)
            {
                //Creates a bullet
                logClone = Instantiate(log, new Vector3(Random.Range(-1.7f, 1.7f), 1.125f, 0), Quaternion.identity) as GameObject;
                timer = spawnTimer;
            }
        }
    }

    public void SetUpManager()
    {
        float powerPercent = (huddy.Power / 1140.0f) * 100;
        if (powerPercent > 80)
        {
            spawnTimer = 0.5f;
        }
        else if (powerPercent > 60)
        {
            spawnTimer = 0.75f;
        }
        else if (powerPercent > 40)
        {
            spawnTimer = 1f;
        }
        else if (powerPercent > 20)
        {
            spawnTimer = 1.25f;
        }
        else
        {
            spawnTimer = 1.5f;
        }

        timer = spawnTimer;
    }
}
