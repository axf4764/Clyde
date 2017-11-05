using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject player;


    // Use this for initialization
    void Start()
    {
        Invoke("Shoot", 1f);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >  1.0f)
        {
            transform.position += transform.forward * 4 * Time.deltaTime;
            //this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, 0.01f);
        }
    }

    public void Shoot()
    {
        if(player != null)
        {
            GameObject bullet = (GameObject)Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            Vector3 direction = player.transform.position - bullet.transform.position;
            bullet.GetComponent<Bullet>().SetDirection(direction);
        }
    }

}
