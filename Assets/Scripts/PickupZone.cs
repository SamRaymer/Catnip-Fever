using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupZone : MonoBehaviour
{
    PlayerCharacter playerCharacter;

    void Start()
    {
        playerCharacter = GetComponentInParent<PlayerCharacter>();
    }

    void Update()
    {

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Cat"))
        {
            Debug.Log("Could pick up a cat");
            playerCharacter.objectToPickUp = collider.gameObject;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
    {
        if (playerCharacter.objectToPickUp == other.gameObject)
        {
            Debug.Log("Can't pick up that cat anymore");
            playerCharacter.objectToPickUp = null;
        }

    }
}
