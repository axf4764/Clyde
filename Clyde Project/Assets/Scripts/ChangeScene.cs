using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Benjamin
public class ChangeScene : MonoBehaviour
{
    // Attributes
    //public Button start;
    //public Button options;

    public string TargetSceneName;
    // Use this for initialization
    void Start()
    {

    }

    //public void Play()
    //{
    //    Application.LoadLevel("Scene1");
    //}

    //public void Options()
    //{
    //    Application.LoadLevel("Options");
    //}

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Player" )
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene( TargetSceneName );
        }
    }
}
