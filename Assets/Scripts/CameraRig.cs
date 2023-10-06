using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour, IPlayerTracking
{
    public Transform playerTransform;

    private void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
    
        if (playerTransform != null)
        {
            // Set the object's position to match the player's position on the X and Z axes
            Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + 5, (playerTransform.position.z-5));
            transform.position = newPosition;
        }
    }
}
