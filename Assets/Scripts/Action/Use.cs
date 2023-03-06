using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // the item could be in many places
        // it can be in the room that the player is in, or in the inventory

        // check room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }
        // check inventory
        if (UseItems(controller, controller.player.inventory, noun))
        {
            return;
        }

        controller.currentText.text = "There is no " + noun;

    }


    private bool UseItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanUseItem(controller, item))
                {
                    if (item.InteractWith(controller, "use"))
                    {
                        // if it isn't successful, the item was found, but there was nothing to interact with
                        return true;
                    }
                }

                
                controller.currentText.text = "The " + noun + " does nothing!";
                return true;
            }
        }

        return false;
    }
}
