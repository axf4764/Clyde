using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour {
    public GameObject healthBar;
    public GameObject healthBarOutline;
    private float health;
    public Text mainText;
    public GameObject player;
    public Sprite failSprite;
    public List<GameObject> icons;
    // Use this for initialization
    void Start () {
        health = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("manager").GetComponent<GoogaManager>().EndSpawning();
            player.transform.position = new Vector3(-7.5f, 1.5f, -2);
            player.GetComponent<SpriteRenderer>().sprite = failSprite;
            int loopLength = GameObject.FindGameObjectsWithTag("googaPlayerIcon").Length;
            for (int i = 0; i < loopLength; i++)
            {
                Destroy(icons[i]);
            }
            
            Destroy(player.GetComponent<Player>());
            mainText.text = "<color=red>Defense  Failed</color>  You'll  get  \'em  next  time";
            mainText.color = new Color(1, 1, 1, 1);
            Destroy(healthBar);
            Destroy(healthBarOutline);
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "strong")
        {
            health -= 0.2f;
        }
        else if(col.tag == "quick" || col.tag == "flying")
        {
            health -= 0.1f;
        }
        healthBar.transform.localScale = new Vector3(health, 0.16f, 1);
    }
}
