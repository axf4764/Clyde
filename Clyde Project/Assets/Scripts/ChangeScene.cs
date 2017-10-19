using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Benjamin
public class ChangeScene : MonoBehaviour
{

    public string TargetSceneName;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( this.enabled )
        {
            if( collision.gameObject.tag == "Player" )
            {
                SceneManager.LoadScene( TargetSceneName );
            }
        }
    }
}
