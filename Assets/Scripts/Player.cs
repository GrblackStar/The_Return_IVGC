using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// store information about the player
public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();

    void Start()
    {

    }

    void Update()
    {

    }


    public bool ChangeLocation(GameController gameController, string  connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if (connection != null)
        {
            if (connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    internal bool CanUseItem(GameController controller, Item item)
    {
        if (item.targetItem == null)
        {
            return true;
        }

        // if it;s not null, we need to check if the atrget item is in the inventory or in the current location:
        if (HasItem(item.targetItem))
        {
            return true;
        }
        if (currentLocation.HasItem(item.targetItem))
        {
            return true;
        }


        return false;
    }

    private bool HasItem(Item itemToCheck)
    {
        foreach (Item item in inventory)
        {
            if (item == itemToCheck  &&  item.itemEnabled)
            {
                return true;
            }
        }

        return false;
    }



}
