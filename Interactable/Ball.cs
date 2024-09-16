using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * sets up interaction for an individual ball 
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class Ball : Interactable
{
    /** the index of the ball in the array of balls */
    public int BallIdx;
    /** current instance of ball placement to replace this ball */
    public BallPlacement ballPlacement;

    /**
     * what happens when the ball is interacted with
     */
    protected override void Interact()
    {

        ballPlacement.PlaceBall(BallIdx);
        DrillTimer.PointsScored += 100;
        //play a satisfying sound here

    }
}
