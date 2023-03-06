using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // the item could be in many places
        // it can be in the room that the player is in, or in the inventory

        // check room
        if (CheckItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }
        // check inventory
        if (CheckItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "You can't see a " + noun;

    }


    private bool CheckItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (item.InteractWith(controller, "examine"))
                {
                    // if it isn't successful, the item was found, but there was nothing to interact with
                    return true;
                }
                controller.currentText.text = "You see " + item.descriprion;

                return true;
            }
        }

        return false;
    }


}
