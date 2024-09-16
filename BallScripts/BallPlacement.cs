using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * places balls in the ball array 
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class BallPlacement : MonoBehaviour
{
    
    public GameObject BallsObj;
    
    public BallAppearPoints BallPoints;

    public Transform InitialBallPosition;

    private DrillTimer drillTimer;

    //Making these public so I can access them elsewhere
    private BallCollection Balls;
    
    // Start is called before the first frame update
    void Start()
    {
        drillTimer = GetComponent<DrillTimer>();
        Balls = BallsObj.GetComponent<BallCollection>();

        Balls.balls.Capacity = drillTimer.NumBalls;

        //adds the given number of balls onto the scene
        for (int i = 0; i < drillTimer.NumBalls; i++)
        {
            Balls.balls.Add(GameObject.Instantiate(Resources.Load("Prefabs/Ball") as GameObject, InitialBallPosition.position, InitialBallPosition.transform.rotation, BallsObj.transform));
            Balls.balls[i].GetComponent<Ball>().BallIdx = i;
            Balls.balls[i].GetComponent<Ball>().ballPlacement = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if the balls are all loaded and in the initial position
        if (DrillTimer.GameInProgress && Balls.balls[Balls.balls.Count - 1].transform.position == InitialBallPosition.position)
        {
            //for each ball in the list of all balls, place the ball in a random location
            for (int i = 0; i < Balls.balls.Count; i++)
            {
                PlaceBall(i);
            }

        //if the game has not started yet and the balls are out of place, put the balls back to their original position
        } else if (!DrillTimer.GameInProgress && Balls.balls[Balls.balls.Count - 1].transform.position != InitialBallPosition.position)
        {
            ResetBalls();
        }
    }


    /**
     * Resets the position of all the balls back to the initial position
     */
    public void ResetBalls()
    {
        for(int i = 0; i < Balls.balls.Count; i++)
        {
            Balls.balls[i].transform.position = InitialBallPosition.position;
        }
    }





    /**
     * This function places a ball in a random location
     * @param BallIdx the index from the list for a ball that needs to be placed
     */
    public void PlaceBall(int BallIdx)
    {
        int BallPointIndex = Random.Range(0, BallPoints.waypoints.Count);

        for (int i = 0; i < Balls.balls.Count; i++)
        {
            if (i != BallIdx && Balls.balls[i].transform.position == BallPoints.waypoints[BallPointIndex].position)
            {
                PlaceBall(BallIdx);
                return;
            }
        }

        Balls.balls[BallIdx].transform.position = BallPoints.waypoints[BallPointIndex].position;
    }
}
