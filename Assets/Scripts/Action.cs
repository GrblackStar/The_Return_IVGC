using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// all actions will inherit from this class
// Actions are not something we want to put in the scene (as a gamee object)
// instead, we want one stored independently from the scene, as assets
// ScriptableObject -->> asset, used to store data and/or execute code
// advantage over a simple class -->> it's serializable; it's properties will be available in the inspector
// can add menu items to the editor

// base class what we use to create all other actions
// ABSTRACT  --->>>  we don't want to create an action object itself; cannot create an instance of the class
public abstract class Action : ScriptableObject
{
    // to identify the action (go, pick, ...)
    public string keyword;

    // responds to the users commands:
    // abstract -->> any child that inherits from Action class, MUST implement this function
    public abstract void RespondToInput(GameController controller, string noun);


}

