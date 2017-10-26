using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Benjamin
//https://github.com/SABentley/Zelda-Dialogue/blob/master/Assets/Scripts/Dialogue.cs
public class Dialogue : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;
    public bool[] hasOptions;

    public float SecondsBetweenCharacters = 0.075f;
    public float CharacterRateMultiplier = 0.4f;

    //
    public string EntranceDestination;
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


    [SerializeField]
    private bool playerInRange = false;

    [SerializeField]
    int currentDialogueIndex = 0;

    private int dialogueLength;

    private bool finishedDrawing = false;

    private PlayerLogic playerRef;

    // Use this for initialization
    void Start()
    {
        _isDialoguePlaying = false;
        _textComponent = dialoguePanel.GetComponentInChildren<Text>();
        _textComponent.text = "";
        if( hasOptions.Length != DialogueStrings.Length )
        {
            bool[] temp = hasOptions;
            hasOptions = new bool[ DialogueStrings.Length ];
            Array.Copy( temp, hasOptions, temp.Length );
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
        if( Input.GetKeyDown( KeyCode.E ) && playerInRange )
        {
            if( !_isDialoguePlaying )
            {
                playerRef.CurrentState = PlayerLogic.PlayerState.Dialogue;
                _isDialoguePlaying = true;
                currentDialogueIndex = 0;
                dialoguePanel.SetActive( true );
                StartCoroutine( StartDialogue() );
            }

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
                if( hasOptions[currentDialogueIndex])
                {
                    _textComponent.text = DialogueStrings[ currentDialogueIndex++ ];
                }
                else
                {
                    StartCoroutine( DisplayString( DialogueStrings[ currentDialogueIndex++ ] ) );
                }
                

                if( currentDialogueIndex >= dialogueLength )
                {

                    if( hasOptions.Length == dialogueLength )
                    {
                        //If it has dialogue options to launch another scene
                        //selecting yes or no can only do a specific thing right now (launching another scene)
                        if( hasOptions[ currentDialogueIndex - 1 ] )
                        {
                            YesIcon.SetActive( true );
                            SelectText.SetActive( true );

                            while( true )
                            {
                                if( Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.D ) )
                                {
                                    YesIcon.SetActive( !YesIcon.activeSelf );
                                    NoIcon.SetActive( !NoIcon.activeSelf );
                                }

                                if( Input.GetKeyDown( DialogueInput ) && YesIcon.activeSelf )
                                {
                                    Initiate.Fade( EntranceDestination, Color.black, 1.0f );
                                    //SceneManager.LoadScene( EntranceDestination );
                                }
                                else if( Input.GetKeyDown( DialogueInput ) && NoIcon.activeSelf )
                                {
                                    finishedDrawing = true;
                                    break;
                                }

                                yield return 0;
                            }
                        }
                    }
                    _isEndOfDialogue = true;
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
                playerRef.CurrentState = PlayerLogic.PlayerState.Default;
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

    //Some hard coded stuff here to clean up later
    private void OnTriggerEnter2D( Collider2D collision )
    {
        if(GameManagerScript.instance.HasWood == true && EntranceDestination == "Googa Rush")
        {
            if( collision.gameObject.tag == "Player" )
            {
                playerRef = collision.gameObject.GetComponent<PlayerLogic>();
                playerInRange = true;
                if( finishedDrawing )
                {
                    finishedDrawing = false;
                    currentDialogueIndex = 0;
                    _isDialoguePlaying = false;
                }
            }
        }
        else if( EntranceDestination != "Googa Rush" && collision.gameObject.tag == "Player" )
        {
            playerRef = collision.gameObject.GetComponent<PlayerLogic>();
            playerInRange = true;
            if( finishedDrawing )
            {
                finishedDrawing = false;
                currentDialogueIndex = 0;
                _isDialoguePlaying = false;
            }
        }


    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Player" )
        {
            playerInRange = false;
            YesIcon.SetActive( false );
            SelectText.SetActive( false );
            NoIcon.SetActive( false );
        }

    }
}