using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * used to change the scene from the current screne to the target, also allows quitting
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class MenuChange : MonoBehaviour
{
    [SerializeField]
    public string TargetScene;

    /**
     * loads the target scene 
     */
    public void NewGame()
    {
        
        SceneManager.LoadScene(TargetScene);
    }

    /**
     * quits the game
     */
    public void QuitGame()
    {
        Application.Quit();
    }
}
