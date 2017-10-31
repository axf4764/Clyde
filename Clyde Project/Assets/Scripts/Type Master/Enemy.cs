using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

    float fireprogress = 0.0f;

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
                fireprogress -= 1.50f;
            }
        }
    }
}
