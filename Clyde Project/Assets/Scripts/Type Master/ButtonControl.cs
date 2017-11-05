using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonControl : MonoBehaviour
{

    private GameController manager;

    // Use this for initialization
    void Start()
    {
        GameObject managerObj = GameObject.FindWithTag("GameController");
        manager = managerObj.GetComponent<GameController>();

        GetComponent<Button>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.GameOver)
        {
            GetComponent<Button>().enabled = true;
            GetComponentInChildren<Text>().enabled = true;
        }
    }
}
