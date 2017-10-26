using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoogaManager : MonoBehaviour {
    //Prefabs for the bullet and its clone
    public GameObject[] Googas;
    private GameObject googaClone;
    public Vector3[] lanes;
    public RawImage[] waveIcons;
    public RawImage googaIcon;
    private float spawnTimer = 1.5f;
    private float timer = 2;
    public float waveTimer = 5;
    public Text mainText;
    private float fadeAmount;
    private List<List<int>> waves;
    private int waveNumber = 1;
    private float iconDist;
    private bool spawnWaves;
    

    // Use this for initialization
    void Start()
    {
        spawnWaves = true;
        waves = new List<List<int>>();
        fadeAmount = 1;
        waves.Add(SetUpWave(8));
        waves.Add(SetUpWave(10));
        waves.Add(SetUpWave(12));
        waves.Add(SetUpWave(15));
        waves.Add(SetUpWave(20));

        iconDist = 100 / waves[0].Count;
    }

    public List<List<int>> Waves
    {
        get
        {
            return waves;
        }
    }

    public bool SpawnWaves
    {
        get
        {
            return spawnWaves;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fadeAmount > 0)
        {
            fadeAmount -= 0.005f;
            mainText.color = new Color(1, 1, 1, fadeAmount);
        }
        if(waveNumber < 6 && waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
            timer = 0;
        }
        if (spawnWaves)
        {

            if (waveTimer <= 0 && waves.Count != 0)
            {

                timer -= Time.deltaTime;
                //Checks to see if spacebar was pressed
                if (timer < 0 && waves[0].Count != 0)
                {
                    if (Googas[waves[0][0]].tag == "flying")
                    {
                        googaClone = Instantiate(Googas[waves[0][0]], lanes[3], Quaternion.identity) as GameObject;
                        googaClone.GetComponent<GoogaMoova>().SetLane(4);
                    }
                    else
                    {
                        int laneSpawn = Random.Range(0, 3);
                        googaClone = Instantiate(Googas[waves[0][0]], lanes[laneSpawn], Quaternion.identity) as GameObject;
                        googaClone.GetComponent<GoogaMoova>().SetLane(laneSpawn + 1);
                    }
                    //Creates a bullet
                    waves[0].RemoveAt(0);
                    googaIcon.rectTransform.position = new Vector2(googaIcon.rectTransform.position.x + iconDist, googaIcon.rectTransform.position.y);
                    timer = spawnTimer;
                    //int boobs = 80085;
                }
                if (waves[0].Count == 0 && GameObject.FindGameObjectsWithTag("flying").Length == 0 && GameObject.FindGameObjectsWithTag("quick").Length == 0 && GameObject.FindGameObjectsWithTag("strong").Length == 0)
                {
                    googaIcon.rectTransform.position = new Vector2(waveIcons[waveNumber].rectTransform.position.x, googaIcon.rectTransform.position.y);
                    waves.RemoveAt(0);
                    waveTimer = 5;
                    mainText.color = new Color(1, 1, 1, 1);
                    waveNumber++;
                    mainText.text = "WAVE " + waveNumber;
                    if (waves.Count != 0)
                    {
                        iconDist = 100 / waves[0].Count;
                        fadeAmount = 1;
                    }

                }
            }
            if (waves.Count == 0)
            {
                if (GameObject.FindGameObjectsWithTag("flying").Length == 0 && GameObject.FindGameObjectsWithTag("quick").Length == 0 && GameObject.FindGameObjectsWithTag("strong").Length == 0)
                    mainText.color = new Color(1, 1, 1, 1);
                mainText.text = "Googas Defeated!";
            }
        }
    }

    public List<int> SetUpWave(int waveLength)
    {
        List<int> wave = new List<int>();
        int lastValue = -1;
        bool repeated = false;
        for (int i = 0; i < waveLength; i++)
        {
            int googaNum = Random.Range(0, 3);
            if(!repeated && googaNum == lastValue)
            {
                repeated = true;
            }
            else if(repeated && googaNum == lastValue)
            {
                do
                {
                    googaNum = Random.Range(0, 3);
                } while (googaNum == lastValue);
                repeated = false;
            }
            
            lastValue = googaNum;
            wave.Add(googaNum);
        }
        return wave;
    }

    public void EndSpawning()
    {
        spawnWaves = false;
    }

    public void ReturnMain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("scene1");
    }

    public void Retry()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Googa Rush");
    }
}
