using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    public Transform playerTransform; // Reference to the player's transform

    void Update()
    {
        if (playerTransform != null)
        {
            // Set the object's position to match the player's position on the X and Z axes
            Vector3 newPosition = new Vector3(playerTransform.position.x, 0f, (playerTransform.position.z+45));
            transform.position = newPosition;
        }
    }
}

