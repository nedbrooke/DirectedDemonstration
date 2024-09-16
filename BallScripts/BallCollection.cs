using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * class that holds list of the balls for the game (implemented this way for use in UI)
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class BallCollection : MonoBehaviour
{
    /** all the ball objects for the game */
    public List<GameObject> balls = new List<GameObject>();
}
