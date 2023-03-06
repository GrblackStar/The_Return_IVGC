using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the items are going to exist in the world -->> MonoBehaviour
public class Item : MonoBehaviour
{
    public string itemName;
    [TextArea]
    public string descriprion;
    // whether the player can take the item
    public bool playerCanTake;
    // thether the item is available/enabled
    // disabled items will not be displayed or interactable with
    public bool itemEnabled = true;

    public Interaction[] interactions;

    public Item targetItem = null;



    // responsible for the actual interactions:
    // bool -->> to signify whether the interaction happened
    public bool InteractWith(GameController controller, string actionKeyword)
    {
        foreach (Interaction interaction in interactions)
        {
            if (interaction.action.keyword == actionKeyword)
            {
                foreach (Item disableItem in interaction.itemsToDisable)
                {
                    disableItem.itemEnabled = false;
                }
                foreach (Item enableItem in interaction.itemsToEnable)
                {
                    enableItem.itemEnabled = true;
                }


                foreach (Connection disableConnection in interaction.connectionsToDisable)
                {
                    disableConnection.connectionEnabled = false;
                }
                foreach (Connection enableConnection in interaction.connectionsToEnable)
                {
                    enableConnection.connectionEnabled = true;
                }


                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);


                return true;
            }
        }
        return false;
    }


}
