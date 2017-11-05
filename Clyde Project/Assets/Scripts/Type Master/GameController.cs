using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Attributes
    public float progress = 0.0f;
    string[] alphabet = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", };

    public static GameController controller;
    public static List<string> keys = new List<string>();
    public static Dictionary<string, KeyIndicator> key2enemy = new Dictionary<string, KeyIndicator>();

    private int lives;
    private int score;

    // UI text info
    public Text scoreText;
    public Text livesText;
    public GameObject retryText;
    public GameObject returnText;

    // Lives Health Bar UI
    public SpriteRenderer lifeSprite;
    public Sprite[] hearts;

    private bool gameOver = false;

    // Properties
    public bool GameOver
    {
        get
        {
            return gameOver;
        }
    }

    // Use this for initialization
    void Start()
    {
        GameController.controller = this;
        scoreText.text = "SCORE: " + score;
        livesText.text = "LIVES: ";
        lifeSprite.sprite = hearts[0];

        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        progress += Time.deltaTime;
        if (progress > 1.5f)
        {
            progress -= 1.5f;
            GameObject instance = Instantiate(Resources.Load("Enemy")) as GameObject;
            instance.transform.position = new Vector2(Random.Range(-1.7f, 1.7f), Random.Range(-0.9f, 0.9f));
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

        if(score > 200)
        {
            SceneManager.LoadScene("Time Travel");
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
            gameOver = true;
            lifeSprite.sprite = null;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("Type Master");
    }

    public void Return()
    {
        SceneManager.LoadScene("Intro Type");
    }
}
