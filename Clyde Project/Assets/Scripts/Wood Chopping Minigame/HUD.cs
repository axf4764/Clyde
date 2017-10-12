using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    //array of text values for UI prompts
    public Text ScoreUI;
    public Text TimeUI;
    public Text WoodUI;
	public Text MiniGameOnePrompt;
	public Text MiniGameTwoPrompt;
    public Text powerBarFull;
    private int score;
    private float timer;
    private int wood;
    private float power;

    public bool stateTwo;
    public bool stateOne;
    public bool stateTwoComplete;
    public bool stateOneComplete;
    private bool countDownActive;
    //array of text values for UI prompts
    public RawImage blackBar;
    public RawImage powerBarOutline;
    public RawImage powerBar;

    private int treeAnimNum;
    private int playerAnimNum;

    public GameObject player;
    public GameObject tree;
    public Sprite[] trees;
    public Sprite[] playerChopping;
    public Sprite playerRunning;

    public float Power
    {
        get
        {
            return power;
        }
    }

    public int Score
    {
        set
        {
            score = value;
        }
        get
        {
            return score;
        }
    }

    public int Wood
    {
        set
        {
            wood = value;
        }
        get
        {
            return wood;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        timer = 5;
        wood = 0;
        countDownActive = true;
        stateOne = false;
        stateTwo = false;
        stateOneComplete = false;
        stateTwoComplete = false;
        powerBarOutline.GetComponent<RawImage>().enabled = false;
        powerBarFull.GetComponent<Text>().enabled = false;

        playerAnimNum = 0;
        treeAnimNum = 0;
}
	
	// Update is called once per frame
	void Update () {
        if (countDownActive)
        {
            if (!stateOneComplete && timer > 0.5)
            {
                timer = (timer - Time.deltaTime);
                MiniGameOnePrompt.text = "CHOP  THE  TREE! BEGINS  IN  " + (int)(timer + 0.5f);
            } else if (stateOneComplete && timer > 0.5)
            {
                timer = (timer - Time.deltaTime);
                MiniGameOnePrompt.text = "CATCH  THE  WOOD! BEGINS  IN  " + (int)(timer + 0.5f);
            }

            if (!stateOneComplete && !stateOne && timer < 1)
            {
                countDownActive = false;
                stateOne = true;
                timer = 10;
                MiniGameOnePrompt.text = "MASH  SPACEBAR!";
                powerBarOutline.GetComponent<RawImage>().enabled = true;
            }

            if (stateOneComplete && timer < 0.5)
            {
                countDownActive = false;
                stateTwo = true;
                timer = 60;
                MiniGameOnePrompt.text = "MOVE  WITH  \"A\"  AND  \"D\"";
                powerBarOutline.GetComponent<RawImage>().enabled = false;
                powerBar.GetComponent<RawImage>().enabled = false;
                powerBarFull.GetComponent<Text>().enabled = false;
                player.GetComponent<PlayerMovementWoodCatching>().enabled = true;
                gameObject.GetComponent<WoodManager>().SetUpManager();
            }

        }
        if (stateOne)
        {
            if (Input.GetKeyDown(KeyCode.Space) && power < 1140)
            {
                player.GetComponent<SpriteRenderer>().sprite = playerChopping[1];
                power += 14.25f;
                //power += 100;
                powerBar.rectTransform.sizeDelta = new Vector2(power, 46.1f);
                score += 10;
                ScoreUI.text = "SCORE:" + score;
                treeAnimNum++;
                if(treeAnimNum > 1)
                {
                    treeAnimNum = 0;
                }
                tree.GetComponent<SpriteRenderer>().sprite = trees[treeAnimNum];
            }
            if (Input.GetKeyUp(KeyCode.Space) && power < 1140)
            {
                player.GetComponent<SpriteRenderer>().sprite = playerChopping[0];
            }

            if (power > 1140)
            {
                power = 1140;
                powerBar.rectTransform.sizeDelta = new Vector2(power, 46.1f);
                powerBarFull.GetComponent<Text>().enabled = true;

            }

            if (timer > 0.5 && power < 1140)
            {
                timer = (timer - Time.deltaTime);
                TimeUI.text = "TIME: " + (int)(timer + 0.5f);
            }
            else
            {
                stateOneComplete = true;
                stateOne = false;
                countDownActive = true;
                timer = 5;
                player.GetComponent<SpriteRenderer>().sprite = playerRunning;
            }
        }

        if (stateTwo)
        {
            ScoreUI.text = "SCORE:" + score;
            WoodUI.text = wood + ":WOOD";
            if (timer > 0.5)
            {
                timer = (timer - Time.deltaTime);
                TimeUI.text = "TIME: " + (int)(timer + 0.5f);
            }
            else
            {
                stateTwoComplete = true;
                stateTwo = false;
                countDownActive = false;
                player.GetComponent<PlayerMovementWoodCatching>().enabled = false;
                MiniGameOnePrompt.text = "YOU  GOT  A  SCORE  OF " + score + "!\n  WITH  " + wood + "  WOOD!";
            }
        }
	}
}
