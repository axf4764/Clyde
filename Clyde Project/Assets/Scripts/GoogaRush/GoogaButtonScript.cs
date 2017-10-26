using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogaButtonScript : MonoBehaviour {

    public GameObject manager;

    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!manager.GetComponent<GoogaManager>().SpawnWaves)
        {
            GetComponent<Button>().enabled = true;
            GetComponentInChildren<Text>().enabled = true;
        }
    }
}
