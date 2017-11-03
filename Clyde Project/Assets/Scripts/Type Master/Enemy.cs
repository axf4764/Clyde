using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    public GameObject missile;
    float fireprogress = 0.0f;
    private float shotsPerSecond = 0.5f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.transform.position, Vector2.zero) > 1.0f)
        {
            //this.transform.LookAt(Vector2.zero);
            this.transform.position = Vector2.MoveTowards(this.transform.position, Vector2.zero, 0.01f);
        }
        else
        {
            fireprogress += Time.deltaTime;
            if (fireprogress > 1.50f)
            {
                Debug.Log("fire");
                Shoot();
                fireprogress -= 1.50f;
            }
        }
    }

    void Shoot()
    {
        Vector3 missilePos = this.transform.position;
        Vector3 playerPos = GameObject.FindWithTag("Player").transform.position;
        GameObject firedMissile = Instantiate(missile, missilePos, Quaternion.identity) as GameObject;
        firedMissile.GetComponent<Rigidbody2D>().velocity = (playerPos - transform.position).normalized * 1;
        
    }
}
