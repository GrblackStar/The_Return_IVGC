using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// store information about the player
public class Player : MonoBehaviour
{
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();


    #region Methods


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

    internal bool CanTalkToItem(GameController controller, Item item)
    {
        return item.playerCanTalkTo;
    }

    internal bool CanGiveToItem(GameController controller, Item item)
    {
        return item.playerCanGiveTo;
    }

    internal bool HasItemByName(string noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                return true;
            }
        }

        return false;
    }

    public void Teleport(GameController controller, Location destination)
    {
        currentLocation = destination;
    }

    internal bool CanReadItem(GameController controller, Item item)
    {
        
       if (item.playerCanRead)
        {
            return true;
        }
        return false;
        /*
        if (item.targetItem == null)
        {
            return true;
        }
        if (HasItem(item.targetItem))
        {
            return true;
        }
        if (currentLocation.HasItem(item.targetItem))
        {
            return true;
        }
        return false;
        */
    }

    #endregion
}
