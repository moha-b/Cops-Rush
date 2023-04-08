using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player's Transform component
    public Transform player;
    // Offset between the camera and player position
    public Vector3 offset;

    void LateUpdate()
    {
        // Check if player is not null
        if (player != null)
        {
            // Set the camera's position to be the same as the player's position plus the offset
            transform.position = player.position + offset;
        }
    }
}
