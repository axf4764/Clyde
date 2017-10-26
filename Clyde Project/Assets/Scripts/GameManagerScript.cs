using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance = null;

    [Header("Variables")]
    private bool hasWood = false;

    //todo add language variable

    public bool HasWood
    {
        get;
        set;
    }
    void Awake()
    {
        if( instance == null )
        { 
            instance = this;
        }
        else if( instance != this )
        { 
            Destroy( gameObject );
        }
        DontDestroyOnLoad( gameObject );

        InitializeVariables();
    }

    // Use this for initialization
    void InitializeVariables()
    {
        //add stuff as needed here
    }

    // Update is called once per frame
    void Update()
    {

    }
}
