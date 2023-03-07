using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        // check room
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
        {
            return;
        }
        // check inventory
        if (ReadItems(controller, controller.player.inventory, noun))
        {
            return;
        }
    }


    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName == noun)
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                    {
                        // if it isn't successful, the item was found, but there was nothing to interact with
                        return true;
                    }
                }


                controller.currentText.text = "You cannot read the  " + noun;
                return true;
            }
        }

        return false;
    }
}
