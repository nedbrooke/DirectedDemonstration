using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * handles the settings menu for the game
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class PlayerSettings : MonoBehaviour
{
    /** instance of current drill timer to tell it when to pause or continue */
    private DrillTimer drillTimer;
    [SerializeField] 
    private GameObject PauseMenuScreen; //screen that is pulled up when paused
    [SerializeField]
    private GameObject SettingsMenuScreen; //screen that is pulled up for the settings
    [SerializeField]
    private GameObject StartButton; //button that starts the game back up
    [SerializeField]
    private TextMeshProUGUI TimerLabel; //label that shows the timer of the game
    [SerializeField]
    private TextMeshProUGUI CountDownLabel; //label that counts down till game starts again

    private bool hasGameStarted; //determines if the game has started
    public bool HasGameStarted {set => hasGameStarted = value;} //pointer that sets value of hasGameStarted
    private bool isPaused; //determines if game is paused
    public bool IsPaused {set => isPaused = value;} //pointer that sets value of isPaused
    private bool gameOver; //determines if game is over
    public bool GameOver {set => gameOver = value;} //pointer that sets game over value

    // Start is called before the first frame update
    void Start()
    {
        
        drillTimer = GetComponent<DrillTimer>();
        isPaused = false;
    }

    /**
     * Deals with input from the escape key, and either opens the pause menu, returns
     * to the pause menu from the settings menu, or continues the game
     */
    public void SettingsMenu()
    {
        if (!isPaused) //if game is not already in the pause menu
        {
            StartButton.SetActive(false);
            drillTimer.PauseGame();
            isPaused = true;
            PauseMenuScreen.SetActive(true);
        } else if (SettingsMenuScreen.activeSelf) //if the settings menu is active
        {
            SettingsMenuScreen.SetActive(false);
            PauseMenuScreen.SetActive(true);
        } else //game is pause in the pause menu
        {
            ContinueGame();
        }
    }

    /**
     * Handles input from pressing the r key, restarts game if the game is paused or over
     */
    public void Restart()
    {
        if (isPaused || gameOver)
        {
            Transform canvas = SettingsMenuScreen.transform.parent;
            canvas.gameObject.GetComponent<GameOnStart>().GameOnStartScreen(); //sets the game to the start screen

            //makes sure that all the buttons and labels are reset
            StartButton.SetActive(true);
            TimerLabel.text = "";
            CountDownLabel.text = "";
        
            //resets isPaused and gameOver back to initial
            isPaused = false;
            gameOver = false;
        }
    }

    /**
     * continues game by closing settings menu
     */
    public void ContinueGame()
    {
        isPaused = false;
        PauseMenuScreen.SetActive(false);
        SettingsMenuScreen.SetActive(false);

        //if the game has started than the timer needs to be restarted otherwise the start button needs to be added back
        if (hasGameStarted)
        {
             drillTimer.ContinueGame();
        } else 
        {
            StartButton.SetActive(true);
        }
    }
}
