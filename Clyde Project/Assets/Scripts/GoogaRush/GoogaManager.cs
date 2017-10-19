using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogaManager : MonoBehaviour {
    //Prefabs for the bullet and its clone
    public GameObject[] Googas;
    private GameObject googaClone;
    public Vector3[] lanes;
    private float spawnTimer = 1.5f;
    private float timer = 2;
    public float totalTimer = 10;
    public Text mainText;
    private float fadeAmount;

    // Use this for initialization
    void Start()
    {
        fadeAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeAmount > 0)
        {
            fadeAmount -= 0.005f;
            mainText.color = new Color(1, 1, 1, fadeAmount);
        }
        if (totalTimer > 0)
        {
            timer -= Time.deltaTime;
            totalTimer -= Time.deltaTime;
            //Checks to see if spacebar was pressed
            if (timer < 0)
            {
                int googaNum = Random.Range(0, 3);
                if (Googas[googaNum].tag == "flying")
                {
                    googaClone = Instantiate(Googas[googaNum], lanes[3], Quaternion.identity) as GameObject;
                    googaClone.GetComponent<GoogaMoova>().SetLane(4);
                }
                else
                {
                    int laneSpawn = Random.Range(0, 3);
                    googaClone = Instantiate(Googas[googaNum], lanes[laneSpawn], Quaternion.identity) as GameObject;
                    googaClone.GetComponent<GoogaMoova>().SetLane(laneSpawn + 1);
                }
                //Creates a bullet

                timer = spawnTimer;
            }
        } else
        {
            mainText.color = new Color(1, 1, 1, 1);
            mainText.text = "Googas Defeated!";
        }
    }
}
