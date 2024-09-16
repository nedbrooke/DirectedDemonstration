using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * controls the timer and score of the game
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class DrillTimer : MonoBehaviour
{
    [Header("Game Elements")]
    public int GameDurationInSeconds; //how long the game should be
    [Range(1,10)]
    public int CountdownSeconds; //amount of time for the countdown
    [Range(1, 51)]
    public int NumBalls; //number of balls that will spawn

    [SerializeField, Header("Game Objects")]
    private TextMeshProUGUI GameTimer; //label to show the users the time remaining
    [SerializeField]
    private TextMeshProUGUI CountdownTimer; //label to show the countdown
    [SerializeField]
    private GameObject PostGameScreen; //screen shown at end of game
    [SerializeField]
    private TextMeshProUGUI ResultLabel; //label that shows resulting score
    [SerializeField]
    private GameObject Crosshair; //player crosshair

    /** the number of minutes the player has left */
    private int numMinutes;
    /** the number of seconds the player has left */
    private float numSec;
    /** if the game is counting down */
    private bool CountingDown;
    /** difference in time for the countdown */
    private float DelTimeCount;
    /** difference in time for the game timer */
    private float DelTimeGame;
    /** player settings object to pause, reset and change settings during game */
    private PlayerSettings playerSettings;

    /** tells other classes if the game is in progress */
    public static bool GameInProgress;
    /** determines the amount of points scored in current round */
    public static int PointsScored;
    
    /**
     * on start set all variables
     */
    void Start()
    {
        CountingDown = false;
        GameInProgress = false;

        playerSettings =  GetComponent<PlayerSettings>();

        //make the crosshair invisible
        Crosshair.SetActive(false);

        PostGameScreen.SetActive(false);
    }

    /**
     * what is done each frame
     */
    void Update()
    {
        if (CountingDown) // controls countdown timer
        {
            DelTimeCount += Time.deltaTime;
            
            if (DelTimeCount >= CountdownSeconds) //if the countdown is over
            {
                CountingDown = false;
                GameInProgress = true;
                CountdownTimer.text = "";
                //make the crosshair visible
                Crosshair.SetActive(true);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            } else
            {
                //updates countdown label
                CountdownTimer.text = string.Format("{0:0}", (float)CountdownSeconds - DelTimeCount);
            }
        }
        if (GameInProgress) // if the game is in progress
        {
            
            

            DelTimeGame += Time.deltaTime;
            if (numMinutes <=0 && (numSec - DelTimeGame) <= 0) // if the game is over
            {
                PauseGame();
                ResultLabel.text = "" + PointsScored;
                PostGameScreen.SetActive(true);
                playerSettings.GameOver = true;
                return;
            } else if (numSec - DelTimeGame < 0) //converts minute to 60 seconds for label
            {
                numMinutes--;
                numSec += 60;
            }

            //the score label that tells remaining time and score
            GameTimer.text = string.Format("{0}:{1:00.0} {2,10}", numMinutes, numSec - DelTimeGame, PointsScored); 
        }
    }

    /** 
     * sets the variables to start up the game
     */ 
    public void StartingGame()
    {
        ResultLabel.text = "";
        CountdownTimer.text = "" + CountdownSeconds;
        numMinutes = (GameDurationInSeconds / 60);
        numSec = (float) (GameDurationInSeconds % 60);
        CountingDown = true;
        DelTimeCount = 0;
        DelTimeGame = 0;
        PointsScored = 0;
    }

    /**
     * Continues game from settings menu
     */
    public void ContinueGame()
    {
        DelTimeCount = 0;
        CountingDown = true;
    }

    /**
     * Pauses game
     */
    public void PauseGame()
    {
        CountdownTimer.text = "";
        GameTimer.text = "";
        playerSettings.HasGameStarted = GameInProgress || CountingDown;
        CountingDown = false;
        GameInProgress = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Crosshair.SetActive(false);
    }
}
