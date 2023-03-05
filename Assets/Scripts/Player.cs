using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// store information about the player
public class Player : MonoBehaviour
{
    public Location currentLocation;


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

}
