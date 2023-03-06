using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a simple class, because they don't exist in the scene
// to be editable in the inspector:
[System.Serializable]
public class Interaction 
{
    // associated with an action:
    public Action action;
    [TextArea]
    public string response;

    // List of which items will be anabled and disabled:
    public List<Item> itemsToDisable = new List<Item>();
    public List<Item> itemsToEnable = new List<Item>();

    // List of which connections will be anabled and disabled:
    public List<Connection> connectionsToDisable = new List<Connection>();
    public List<Connection> connectionsToEnable = new List<Connection>();




}
