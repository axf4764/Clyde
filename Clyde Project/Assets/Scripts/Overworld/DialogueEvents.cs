using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Benjamin
//TODO - animations, ran into some issues so I'll work on other stuff for now
//This script is meant to play animations by seeing what the current dialogue index is in CutsceneDialogue
//Cutting off animations early if the player proceeds quickly.
[RequireComponent(typeof(CutsceneDialogue))]
public class DialogueEvents : MonoBehaviour
{

    public CutsceneDialogue cutsceneDialogue;

    //Ran into some issues so only one animation per dialogue index right now
    [Header("Put 1 animation for every dialogue string here")]
    public Animation[] animations;
    // Use this for initialization
    void Start()
    {
        cutsceneDialogue = GetComponent<CutsceneDialogue>();

        //resize to match number of dialogue strings + 1, final animation plays after the last dialogue string
        if( animations.Length != cutsceneDialogue.DialogueStrings.Length + 1 )
        {
            Animation[] temp = animations;
            animations = new Animation[ cutsceneDialogue.DialogueStrings.Length + 1];
            Array.Copy( temp, animations, temp.Length );
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( cutsceneDialogue.currentDialogueIndex > 0)
        {
            //animations[ cutsceneDialogue.currentDialogueIndex ].Play()
        }
        //Need to play all animations at the current index, and keep track of what is playing? animations might
        //do that for me already though..
        //Have to make sure animations at previous index are not currently playing if index > 0 at least

    }
 
}

