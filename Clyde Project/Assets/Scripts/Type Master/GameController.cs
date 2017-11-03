using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    float progress = 0.0f;
    string[] alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };

    public static GameController controller;
    public static List<string> keys = new List<string>();
    public static Dictionary<string, KeyIndicator> key2enemy = new Dictionary<string, KeyIndicator>();

    private int lives;
    private int score;

    const int buttonWidth = 120;
    const int buttonHeight = 60;

    // UI text info
    public Text scoreText;
    public Text livesText;
    public GameObject retryText;

    // Lives Health Bar UI
    public SpriteRenderer lifeSprite;
    public Sprite[] hearts;


    // Use this for initialization
    void Start()
    {
        GameController.controller = this;
        scoreText.text = "SCORE: " + score;
        livesText.text = "LIVES: ";
        lifeSprite.sprite = hearts[0];

        score = 0;
        lives = 3;

        retryText.GetComponent<Text>().enabled = false;
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
                score += 10;
                scoreText.text = "SCORE: " + score;

            }
        }

        if(score == 200)
        {
            if(GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (1 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "RETRY"))
            {
                
            }
        }
    }

    public void MinusLives()
    {
        lives--;
        livesText.text = "LIVES:";

        if(lives == 2)
        {
            lifeSprite.sprite = hearts[1];
        }
        if (lives == 1)
        {
            lifeSprite.sprite = hearts[2];
        }
        if(lives < 1)
        {
            Retry();
        }
    }

    public void Retry()
    {
        lifeSprite.sprite = null;
        retryText.GetComponent<Text>().enabled = true;
        SceneManager.LoadScene("Type Master");
    }
}
