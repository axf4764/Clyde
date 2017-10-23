using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ObjectManager Script
/// This script is to be attached to the SceneManager
/// A script that randomly generates Googas in the scene, the Googas are chosen at random
/// Controls the UI events such as score, lives
/// Checks player lives and player score
/// </summary>

public class ObjectManager : MonoBehaviour
{
    // Attributes
    public List<GameObject> googas;
    public GameObject quickGooga;
    public GameObject strongGooga;
    public GameObject flyingGooga;

    public GameObject player;

    // Health bar UI, 3 heart sprites
    public SpriteRenderer lifeSprite;
    public Sprite[] hearts;

    // Information pertaining to player stats
    private int score;
    private int lives;
    private int googaIncrement;
    private int numGoogas;

    // UI text info
    public Text scoreText;
    public Text livesText;

    // Methods
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindWithTag("Player");

        googaIncrement = 4;

        googas.Add(flyingGooga);
        googas.Add(quickGooga);
        googas.Add(strongGooga);

        StartGame();
	}

    /// <summary>
    /// Sets the variables for start of game
    /// Sets the text objects and properties
    /// </summary>
    void StartGame()
    {
        score = 0;
        lives = 3;

        scoreText.text = "Score: " + score;
        livesText.text = "Lives: ";
        lifeSprite.sprite = hearts[0];

        GoogaGeneration();
    }

    /// <summary>
    /// Determines how many Googas are required, dependent on player score
    /// Spawns Googas at random positions using Random.Range
    /// Chooses random Googa prefab from Googas list
    /// </summary>
    void GoogaGeneration()
    {
        // Number of Googas dependent on player score
        numGoogas = (score * googaIncrement);
        for(int i = 0; i < numGoogas; i++)
        {
            // Instantiate a random Googa
            Instantiate(googas[Random.Range(0, googas.Count)], new Vector3(Random.Range(-9.0f, 9.0f), Random.Range(-6.0f, 6.0f), 0), Quaternion.Euler(0, 0, Random.Range(-0.0f, 359.0f)));
        }
    }
	
    /// <summary>
    /// Score is incremented and text is updated
    /// </summary>
    public void IncrementScore()
    {
        scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Controls the player's lives and updates text
    /// </summary>
    public void MinusLives()
    {
        lives--;
        livesText.text = "Lives: ";

        if(lives == 2)
        {
            lifeSprite.sprite = hearts[1];
        }
        if(lives == 1)
        {
            lifeSprite.sprite = hearts[2];
        }
        if(lives < 1)
        {
            lifeSprite.sprite = null;
            // Application.LoadLevel("GameOver"); // or reset level
        }
    }

    /// <summary>
    /// Destroys the Googa
    /// </summary>
    public void DestroyGooga()
    {
        numGoogas--;
    }


	// Update is called once per frame
	void Update ()
    {
        // If the player has destroyed all the asteroids, ... ???
		if(numGoogas < 1)
        {
            GoogaGeneration();
        }
	}
}
