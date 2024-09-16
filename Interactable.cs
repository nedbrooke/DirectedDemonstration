using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * determines how an interactable event handles interaction
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public abstract class Interactable : MonoBehaviour
{
    /** if the interaction is active/ in use */
    public bool useEvents;

    /**
     * determines interaction given if the interaction was activated, and Interacts
     */
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }

        Interact();
    }

    /**
     * interaction events defined in unity UI 
     */
    protected virtual void Interact() { }
}
