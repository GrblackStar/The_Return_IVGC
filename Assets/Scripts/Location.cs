using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MONOBIHAVIOR --->>> all component classes derive from this base class. that's how they get
// their transform properties, start, update, etc.
// the class can be used as a component
// than we add the new properties to give the class custom behaviour


public class Location : MonoBehaviour
{
    public string locationName;
    // adding an attribute to display the field better in the inspector
    [TextArea]
    public string description;
    public Connection[] connections;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // return a list of connections
    public string GetConnectionsText()
    {
        string result = string.Empty;
        foreach (Connection c in connections)
        {
            if (c.connectionEnabled)
            {
                result += c.description + "\n";
            }
        }
        return result;
    }


}
