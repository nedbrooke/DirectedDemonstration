using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * sets the game scene to how it should be when pulled up
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class GameOnStart : MonoBehaviour
{
    /**
     * sets how the screen should be on start
     */
    void Start()
    {
        GameOnStartScreen();
    }

    /**
     * deactivates all child screens except the first child of the current screen
     */
    public void GameOnStartScreen()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
