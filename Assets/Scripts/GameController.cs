using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

// in charge of player interactions
// controlls the user input and the overall game flow
public class GameController : MonoBehaviour
{
    public Player player;

    // access to the UI fields
    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    [TextArea]
    public string introText;

    // available actions:
    public Action[] actions;


    // Start is called before the first frame update
    void Start()
    {
        // when the game starts, we want the intro text to be displayed in the log text area
        logText.text = introText;
        // we want the start location to e displayed
        DisplayLocation();
        // set the text entry field to be active: setting the cursor active; user can just start typing
        textEntryField.ActivateInputField();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //displaying the location that the user is currently at
    public void DisplayLocation()
    {
        string description = player.currentLocation.description + "\n";
        // return a list of connections
        description += player.currentLocation.GetConnectionsText();
        currentText.text = description;

    }


    // event called when a text is entered:
    public void TextEntered()
    {
        //Debug.Log("Text entered");
        LogCurrentText();
        ProcessInput(textEntryField.text);

        // preparing the field for next input
        // clear and set the cursor back to active:
        textEntryField.text = "";
        //textEntryField.text = string.Empty;
        textEntryField.ActivateInputField();
    }


    // send the text to history
    void LogCurrentText()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n\n";
        // the input, but with color tags
        logText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
    }


    // process the input commands:
    // private by default
    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] separatedWords = input.Split(delimiter);
        //string[] separatedWords = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

        // process the commands
        foreach (Action action in actions)
        {
            if (action.keyword.ToLower() == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        
        currentText.text = "Nothing happens!  (having trouble? type Help)";

    }



}
