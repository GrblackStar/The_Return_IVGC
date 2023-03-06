using System;
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

    // the number of items can change, while the game is running  -->> List
    public List<Item> items = new List<Item>();


    void Start()
    {
        
    }

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

    public Connection GetConnection(string connectionNoun)
    {
        foreach (Connection c in connections)
        {
            if (c.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return c;
            }
        }
        return null;
    }

    // display the list of items:
    public string GetItemsText()
    {
        if (items.Count == 0) 
            return string.Empty;
        string result = "You see ";

        bool first = true;
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (!first)
                    result += " and ";
                result += item.descriprion;
                first = false;
            }
            
        }
        result += "\n";
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck  &&  item.itemEnabled)
            {
                return true;
            }
        }

        return false;

    }



}
