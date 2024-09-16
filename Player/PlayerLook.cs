using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * class for determing how screen is effected by mouse movements/ looking
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class PlayerLook : MonoBehaviour
{
    

    public Camera cam; //player camera/ where they view from
    private float xRotation = 0f; //initial rotation on x axis

    public float xSensitivity = 1f; //sensitivity on the x axis
    public float ySensitivity = 1f; //sensitivity on the y axis

    //adding this field so that we can adjust the sensitivity, im keeping the other two (x and y sensitivity) in case we want to adjust one but not the other
    [SerializeField]
    public float sensitivityMultiplier = 30f; 

    /**
     * processes how the players mouse change should effect the camera angle
     *
     * @param input the 2d vector of how the mouse has moved
     */
    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity * sensitivityMultiplier;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity * sensitivityMultiplier);
    }

    /**
     * Increases Mouse Sensitivity
     */
    public void IncreaseSensitivity()
    {
        sensitivityMultiplier += 10;
    }

    /**
     * Decreases Mouse Sensitivity
     */
    public void DecreaseSensitivity()
    {
        sensitivityMultiplier -= 10;
    }

    public void ChangeSens(float NewSens)
    {
        sensitivityMultiplier = NewSens;
    }

    /**
     * Changes the y axis sensitivity
     */
    public void ChangeYSens(float ySens)
    {
        ySensitivity = ySens;
    }

    /**
     * Changes the x axis sensitivity
     */
    public void ChangeXSens(float xSens)
    {
        xSensitivity = xSens;
    }
}
