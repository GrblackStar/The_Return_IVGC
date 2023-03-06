using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// simple class, not deriving from anything:
// by default, a class, that doesn't derive from MonoBehaviour, won't be edditable in the inspector
// to fix this, we are going to add a System.Serializable attribute to the class
// Serializable embeds a class with sub properties in the inspector
//[System.Serializable]


public class Connection : MonoBehaviour
{
    public string connectionName;
    public string description;
    
    public Location location;           // target location
    public bool connectionEnabled;      // if the location is active or not


}
