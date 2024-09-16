using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * class that allows player to interact with object
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class PlayerInteract : MonoBehaviour
{

    private Camera cam; //camera of player

    [SerializeField]
    private float distance = 10f; //how far the ray will go from the camera
    [SerializeField]
    private LayerMask mask; //determines that the object hit has the correct layering

    private InputManager inputManager; //used to trigger events

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //This is the basic raycast stuff 
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;


        //If the user shoots/interacts
        if (inputManager.onFoot.Interact.triggered)
        {
            //if the object is in the Interactable layer
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                //if player hits an interactable, play the interaction
                if (hitInfo.collider.GetComponent<Interactable>() != null)
                {
                    Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                    interactable.BaseInteract();
                    return;

                }
            }

            //Remove points if the player misses
            DrillTimer.PointsScored -= 50;

        }
    }
}
