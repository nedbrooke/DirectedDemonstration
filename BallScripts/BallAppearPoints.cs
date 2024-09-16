using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * class for the list of where the ball can appear (implementation like this for use in UI) 
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class BallAppearPoints : MonoBehaviour
{
    /** list of where balls can spawn */
    public List<Transform> waypoints = new List<Transform>();
}
