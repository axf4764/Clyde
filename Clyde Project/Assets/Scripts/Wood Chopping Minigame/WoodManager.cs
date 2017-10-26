using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodManager : MonoBehaviour {

    //Reference to the player
    public GameObject player;
    //Prefabs for the bullet and its clone
    public GameObject log;
    private GameObject logClone;
    //Timers to track how long between spawning wood and timer for keeping track of wood spawn times
    private float spawnTimer = 0;
    private float timer = 0;
    //Reference to the scene manager
    private HUD huddy;

    // Use this for initialization
    void Start()
    {
        //Find the hud script
        huddy = GameObject.FindGameObjectWithTag("manager").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Checks to see if the wood catching phase has begun
        if (huddy.stateTwo)
        {
            //Decrements the timer
            timer -= Time.deltaTime;
            //Checks to see if the timer has run out
            if (timer < 0)
            {
                float maxX = player.transform.position.x + 1;
                while(maxX > 1.7f)
                {
                    maxX -= 0.1f;
                }
                float minX = player.transform.position.x - 1;
                while (minX < -1.7f)
                {
                    minX += 0.1f;
                }
                //Creates a log
                logClone = Instantiate(log, new Vector3(Random.Range(minX, maxX), 1.125f, -1), Quaternion.identity) as GameObject;
                timer = spawnTimer;
            }
        }
    }

    public void SetUpManager()
    {
        //Calculate the percentage of power bar
        float powerPercent = (huddy.Power / 1.075f) * 100;

        //Set up the spawn timer
        if (powerPercent > 90)
        {
            spawnTimer = 0.65f;
        }
        else if (powerPercent > 60)
        {
            spawnTimer = 1f;
        }
        else if (powerPercent > 40)
        {
            spawnTimer = 1.25f;
        }
        else if (powerPercent > 20)
        {
            spawnTimer = 1.5f;
        }
        else
        {
            spawnTimer = 2f;
        }

        //Set the timer as the spawn timer
        timer = spawnTimer;
    }
}
