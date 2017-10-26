using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Benjamin
//https://github.com/SABentley/Zelda-Dialogue/blob/master/Assets/Scripts/Dialogue.cs modified
public class CutsceneDialogue : MonoBehaviour
{
    private Text _textComponent;

    [Header("txt file name")]
    public string fileToLoad;

    [Header("Enter Dialogue in Order here if not loading from file")]
    public string[] DialogueStrings;
    //public bool[] hasOptions;

    [Header("Variables")]
    public float SecondsBetweenCharacters = 0.075f;
    public float CharacterRateMultiplier = 0.4f;

    //
    //public string EntranceDestination;
    private KeyCode DialogueInput = KeyCode.E;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;
    public GameObject dialoguePanel;
    public GameObject YesIcon;
    public GameObject NoIcon;
    public GameObject SelectText;
    
    
    public int currentDialogueIndex = 0;

    private int dialogueLength;

    private bool finishedDrawing = false;

    [Header("Scene to switch to after finished dialogue if applicable")]
    public string targetScene;
    void Start()
    {
        _isDialoguePlaying = false;
        _textComponent = dialoguePanel.GetComponentInChildren<Text>();
        _textComponent.text = "";
        TextAsset textAsset;

        //in case of localization one day 
        string language = "English";

        if(fileToLoad != null)
        {
            textAsset = Resources.Load<TextAsset>( "DialogueLines/" + language + "/" + fileToLoad );
            if( textAsset == null )
            {
                Debug.Log( "Tried to load file: " + "DialogueLines/" + language + "/" + fileToLoad + ", but failed" );
                return;
            }
            else
            {
                int nLines = 0;

                for( int index = 0; index < textAsset.text.Length; index++ )
                {
                    if(textAsset.text[index] == '\n')
                    {
                        nLines++;
                    }
                }

                DialogueStrings = new string[ nLines ];

                int currentLine = 0;

                for( int index = 0; index < textAsset.text.Length; index++ )
                {
                    if( textAsset.text[ index ] == '\n' )
                    {
                        currentLine++;
                    }
                    else if( index != textAsset.text.Length )
                    {
                        DialogueStrings[ currentLine ] += textAsset.text[ index ];
                    }
                }
            }
        }

        HideIcons();

    }

    // Update is called once per frame
    void Update()
    {
        if(DialogueStrings.Length <= 0)
        {
            return;
        }
        if( !_isDialoguePlaying )
        {
            _isDialoguePlaying = true;
            currentDialogueIndex = 0;
            dialoguePanel.SetActive( true );
            StartCoroutine( StartDialogue() );
        }
        if( Input.GetKeyDown( KeyCode.Return ) )
        {
            currentDialogueIndex = DialogueStrings.Length - 1;
        }
        
    }

    private IEnumerator StartDialogue()
    {
        dialogueLength = DialogueStrings.Length;


        while( currentDialogueIndex < dialogueLength || !_isStringBeingRevealed )
        {
            if( !_isStringBeingRevealed )
            {
                _isStringBeingRevealed = true;

                //instantly display if player has an choice to make
                
                StartCoroutine( DisplayString( DialogueStrings[ currentDialogueIndex++ ] ) );
                

                if( currentDialogueIndex >= dialogueLength )
                {

                    _isEndOfDialogue = true;
                    if( targetScene != null )
                        SceneManager.LoadScene( targetScene );
                }
            }

            yield return 0;
        }
        while( true )
        {
            //final part before exiting
            if( Input.GetKeyDown( DialogueInput ) && finishedDrawing  )
            {
                dialoguePanel.SetActive( false );
                //playerRef.CurrentState = PlayerLogic.PlayerState.Default;
                break;
            }

            yield return 0;
        }

        HideIcons();
        _isEndOfDialogue = false;

    }

    private IEnumerator DisplayString( string stringToDisplay )
    {
        int stringLength = stringToDisplay.Length;

        int currentCharacterIndex = 0;

        HideIcons();

        _textComponent.text = "";

        while( currentCharacterIndex < stringLength )
        {
            _textComponent.text += stringToDisplay[ currentCharacterIndex ];
            currentCharacterIndex++;

            if( currentCharacterIndex < stringLength )
            {
                if( Input.GetKey( DialogueInput ) )
                {
                    yield return new WaitForSeconds( SecondsBetweenCharacters * CharacterRateMultiplier );
                }
                else
                {
                    yield return new WaitForSeconds( SecondsBetweenCharacters );
                }
            }
            else
            {
                if( currentDialogueIndex == dialogueLength )
                {
                    finishedDrawing = true;
                }

                break;
            }
        }

        ShowIcon();

        while( true )
        {
            if( Input.GetKeyDown( DialogueInput ) )
            {
                break;
            }

            yield return null;
        }

        HideIcons();

        _isStringBeingRevealed = false;
        _textComponent.text = "";
    }

    private void HideIcons()
    {
        ContinueIcon.SetActive( false );
        StopIcon.SetActive( false );
    }

    private void ShowIcon()
    {
        if( _isEndOfDialogue )
        {
            StopIcon.SetActive( true );
            return;
        }

        ContinueIcon.SetActive( true );
    }

   
}