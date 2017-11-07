using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnScreen : MonoBehaviour
{
    public GameObject Clyde;
    public GameObject CutSceneManager;
    private CutsceneDialogue dialogue;
    public Transform targetPosition;

    // Use this for initialization
    void Start()
    {
        dialogue = CutSceneManager.GetComponent<CutsceneDialogue>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if( dialogue.currentDialogueIndex > 8 )
        {
            Clyde.transform.position = Vector3.Lerp( Clyde.transform.position, targetPosition.position, Time.deltaTime * 1.0f );
        }
    }
}
