using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/**
 * handles user input such as pausing, restarting, and looking around scene
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class InputManager : MonoBehaviour
{

    /** object that holds what input is being performed  */
    private PlayerInput playerInput;
    /** actions defined in onFoot */
    public PlayerInput.OnFootActions onFoot;
    /** object that controls if/ how the player looks  */
    private PlayerLook playerLook;
    /** object that pulls up the settings menu */
    private PlayerSettings playerSettings;

    /**
     * function that defines everything when the scene is started
     */
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        playerLook = GetComponent<PlayerLook>();
        playerSettings = GetComponent<PlayerSettings>();

        onFoot.Restart.performed += ctx => playerSettings.Restart();
        onFoot.Settings.performed += ctx => playerSettings.SettingsMenu();
    }

    /**
     * determines if/how where the player is looking should change
     */
    void LateUpdate()
    {
        if (DrillTimer.GameInProgress)
        {
            playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
            
    }

    /**
     * enables onFoot actions to be read
     */
    private void OnEnable()
    {
        onFoot.Enable();
    }

    /** 
     * disables on foot actions from being read
     */
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
