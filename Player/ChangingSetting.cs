using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/** 
 * class that changes the settings of the player
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class ChangingSetting : MonoBehaviour
{
    [SerializeField]
    private Slider SensSlider; //slider that gives sensitivity
    [SerializeField] 
    private TMP_InputField SensInputField; //input field for the sensitivity

    private PlayerLook playerLook; //changes the sensitivity inside of player look
    // Start is called before the first frame update
    void Start()
    {
        playerLook = GetComponent<PlayerLook>();
    }

    /**
     * changes the sensitivity on the slider
     */
    public void UpdateSensFromSlider()
    {
        float InputFromField = Mathf.Round(SensSlider.value * 1000) / 1000f;
        SensInputField.text = string.Format("{0:.000}", InputFromField);
        playerLook.ChangeSens(InputFromField);
    }

    /**
     * changes the sensitivity based on input from input field
     */
    public void UpdateSensFromInputField()
    {
        float InputFromField = float.Parse(SensInputField.text);
        InputFromField = Mathf.Round(InputFromField * 1000) / 1000f;
        Debug.Log(string.Format("{0:.000}", InputFromField));
        SensSlider.value = InputFromField;
        playerLook.ChangeSens(InputFromField);
    }

}
