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
	public Text roundCounter;
    public Text powerBarFull;
    public Button returnButton;
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

    private int roundNum;

    public GameObject player;
    public GameObject tree;
    public Sprite[] trees;
    public Sprite[] playerChopping;
    public Sprite playerRunning;

    //Benjamin - adding some stuff for gamemanager's sake
    public bool gameComplete = false;
    private int endGameTimer = 0;
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

    public int RoundNum
    {
        set
        {
            roundNum = value;
        }
        get
        {
            return roundNum;
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
        timer = 3;
        wood = 0;
        countDownActive = true;
        stateOne = false;
        stateTwo = false;
        stateOneComplete = false;
        stateTwoComplete = false;
        powerBarOutline.GetComponent<RawImage>().enabled = false;
        powerBarFull.GetComponent<Text>().enabled = false;
        treeAnimNum = 0;
        roundNum = 1;
}
	
    IEnumerator NextScene()
    {
        endGameTimer++;
        yield return new WaitForSeconds( 1 );
    }
	// Update is called once per frame
	void Update () {

        if( gameComplete )
        {
            StartCoroutine(NextScene());
            if( endGameTimer >=4 )
            {
                //TODO: change this to a variable instead of hardcoded
                UnityEngine.SceneManagement.SceneManager.LoadScene( "Main" );
            }
        }

        if (countDownActive)
        {
            roundCounter.text = "ROUND:" + roundNum + "OF3";
            if (roundNum > 3)
            {
                roundCounter.text = "ROUND:3OF3";
                countDownActive = false;
                MiniGameOnePrompt.text = "YOU  GOT  A  SCORE  OF " + score + "!\n  WITH  " + wood + "  WOOD!";

                GameManagerScript.instance.HasWood = true;

                gameComplete = true;

                return;
            }

            if (!stateOneComplete && timer > 0.5)
            {
                timer = (timer - Time.deltaTime);
                MiniGameOnePrompt.text = "CHOP  THE  TREE! BEGINS  IN  " + (int)(timer + 0.5f);
            } else if (stateOneComplete && timer > 0.5)
            {
                timer = (timer - Time.deltaTime);
                MiniGameOnePrompt.text = "CATCH  THE  WOOD! BEGINS  IN  " + (int)(timer + 0.5f);
            }

            if (!stateOneComplete && !stateOne && timer < 0.5)
            {
                countDownActive = false;
                stateOne = true;
                timer = 5;
                MiniGameOnePrompt.text = "MASH  SPACEBAR!";
                powerBarOutline.GetComponent<RawImage>().enabled = true;
                powerBar.GetComponent<RawImage>().enabled = true;
                powerBar.rectTransform.localScale = new Vector3(power, powerBar.rectTransform.localScale.y, powerBar.rectTransform.localScale.z);
                power = 0;
            }

            if (stateOneComplete && timer < 0.5)
            {
                countDownActive = false;
                stateTwo = true;
                timer = 15;
                MiniGameOnePrompt.text = "MOVE  WITH  \"A\"  AND  \"D\"";
                powerBarOutline.GetComponent<RawImage>().enabled = false;
                powerBar.GetComponent<RawImage>().enabled = false;
                if (powerBarFull.GetComponent<Text>().enabled)
                {
                    powerBarFull.text = "SPEED BOOST!";
                    player.GetComponent<PlayerMovementWoodCatching>().movePos = 2.25f;
                } else
                {
                    powerBarFull.GetComponent<Text>().enabled = false;
                    player.GetComponent<PlayerMovementWoodCatching>().movePos = 1.5f;
                }
                player.GetComponent<PlayerMovementWoodCatching>().enabled = true;
                gameObject.GetComponent<WoodManager>().SetUpManager();
            }

        }
        if (stateOne)
        {
            if (Input.GetKeyDown(KeyCode.Space) && power < 1.705f)
            {
                player.GetComponent<SpriteRenderer>().sprite = playerChopping[1];
                power += 0.036f;
                //power += 100;
                powerBar.rectTransform.localScale = new Vector3(power, powerBar.rectTransform.localScale.y, powerBar.rectTransform.localScale.z);
                score += 10;
                ScoreUI.text = "SCORE:" + score;
                treeAnimNum++;
                if(treeAnimNum > 1)
                {
                    treeAnimNum = 0;
                }
                tree.GetComponent<SpriteRenderer>().sprite = trees[treeAnimNum];
            }
            if (Input.GetKeyUp(KeyCode.Space) && power < 1.075f)
            {
                player.GetComponent<SpriteRenderer>().sprite = playerChopping[0];
            }

            if (power > 1.075f)
            {
                power = 1.075f;
                powerBar.rectTransform.localScale = new Vector3(power, powerBar.rectTransform.localScale.y, powerBar.rectTransform.localScale.z);
                powerBarFull.text = "MAXIMUM POWER";
                powerBarFull.GetComponent<Text>().enabled = true;

            }

            if (timer > 0.5 && power < 1.075f)
            {
                timer = (timer - Time.deltaTime);
                TimeUI.text = "TIME: " + (int)(timer + 0.5f);
            }
            else
            {
                stateOneComplete = true;
                stateOne = false;
                stateTwoComplete = false;
                countDownActive = true;
                timer = 3;
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
                countDownActive = true;
                stateTwoComplete = true;
                stateTwo = false;                
                stateOneComplete = false;
                player.GetComponent<PlayerMovementWoodCatching>().enabled = false;
                powerBarFull.GetComponent<Text>().enabled = false;
                timer = 3;
                roundNum++;
                if(roundNum <= 3)
                {
                    roundCounter.text = "ROUND: " + roundNum + " OF 3";
                    player.GetComponent<SpriteRenderer>().sprite = playerChopping[0];
                    player.transform.position = new Vector3(-0.269f, player.transform.position.y, player.transform.position.z);
                    player.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
        }
	}

    public void ChangeScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
}
