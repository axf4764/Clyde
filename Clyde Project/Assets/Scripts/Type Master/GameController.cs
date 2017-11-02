using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    float progress = 0.0f;
    string[] alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };

    public static GameController controller;
    public static List<string> keys = new List<string>();
    public static Dictionary<string, KeyIndicator> key2enemy = new Dictionary<string, KeyIndicator>();

    // Use this for initialization
    void Start()
    {
        GameController.controller = this;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > 0.5f)
        {
            progress -= 0.5f;
            GameObject instance = Instantiate(Resources.Load("Enemy")) as GameObject;
            instance.transform.position = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-1.0f, 1.0f));
            //instance.transform.rotation = Quaternion.identity;

        }

        foreach (string letter in alphabet)
        {
            if (Input.GetKeyDown(letter))
            {
                keys.Remove(letter);
                key2enemy[letter].Destroy();
                key2enemy.Remove(letter);
            }
        }
    }
}
