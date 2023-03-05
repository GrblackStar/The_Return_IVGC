using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create the actual Help asset in the project:
[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    // OVERRIDE  --->>> overriding the method in the base class
    public override void RespondToInput(GameController controller, string verb)
    {
        controller.currentText.text = "Type a Verb followed by a noun(e.g. \"go north\")";
        controller.currentText.text += "\nAllowed verbs:\nGo, Examine, Get, Give, Use, Inventory, TalkTo, Say, Help";
    }
}
