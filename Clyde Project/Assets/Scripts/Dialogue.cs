using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Benjamin
//https://github.com/SABentley/Zelda-Dialogue/blob/master/Assets/Scripts/Dialogue.cs
public class Dialogue : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.075f;
    public float CharacterRateMultiplier = 0.4f;

    private KeyCode DialogueInput = KeyCode.E;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    private bool _isEndOfDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;
    public GameObject dialoguePanel;

    [SerializeField]
    private bool playerInRange = false;

    [SerializeField]
    int currentDialogueIndex = 0;

    private int dialogueLength;

    private bool finishedDrawing = false;

    // Use this for initialization
    void Start()
    {
        _textComponent = dialoguePanel.GetComponentInChildren<Text>();
        _textComponent.text = "";

        HideIcons();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.E ) && playerInRange )
        {
            if( !_isDialoguePlaying )
            {
                _isDialoguePlaying = true;
                currentDialogueIndex = 0;
                StartCoroutine( StartDialogue() );
            }

        }
        if( _isStringBeingRevealed )
        {
            dialoguePanel.SetActive( true );
        }
        else
        {
            dialoguePanel.SetActive( false );
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
                StartCoroutine( DisplayString( DialogueStrings[ currentDialogueIndex++ ] ) );

                if( currentDialogueIndex >= dialogueLength )
                {
                    _isEndOfDialogue = true;
                }
            }

            yield return 0;
        }
        while( true )
        {
            if( Input.GetKeyDown( DialogueInput ) && finishedDrawing )
            {
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

    private void OnTriggerEnter2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Player")
        {
            playerInRange = true;
            if(finishedDrawing)
            {
                finishedDrawing = false;
                currentDialogueIndex = 0;
                _isDialoguePlaying = false;
            }
        }
        
    }

    private void OnTriggerExit2D( Collider2D collision )
    {
        if( collision.gameObject.tag == "Player")
        {
            playerInRange = false;
            
        }

    }
}