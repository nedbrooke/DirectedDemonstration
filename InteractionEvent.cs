using UnityEngine.Events;
using UnityEngine;

/** 
 * creates parent class so all interactions have method OnInteract
 *
 * @author Bilal Ameen
 * @author Nathan Edbrooke
 */
public class InteractionEvent : MonoBehaviour
{
    /**
     * event that occurs when interactable object is interacted with
     */
    public UnityEvent OnInteract;
}
