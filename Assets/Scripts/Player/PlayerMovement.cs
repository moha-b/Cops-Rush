using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    // Variable to control the speed of player movement
    float xSpeed;
    // Specify the maximum position on the X-axis
    float maxPosition = 4.10f;
    public bool isPlayerRunning;

    void Update()
    {
        if (isPlayerRunning == false)
        {
            return;
        }
        Movements();
    }

    void Movements()
    {
        // Variable to store the horizontal touch/mouse input
        float touchX = 0;
        // Variable to store the resulting horizontal movement
        float movementOnX = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Set the horizontal movement speed
            xSpeed = 250;
            // Get the horizontal delta position of the touch input
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            // Set the horizontal movement speed
            xSpeed = 500;
            // Get the horizontal input axis of the mouse
            touchX = Input.GetAxis("Mouse X"); 
        }
        // Calculate the resulting horizontal movement
        movementOnX = transform.position.x + xSpeed * touchX * Time.deltaTime;
        // Clamp the resulting movement within the maximum position range
        movementOnX = Mathf.Clamp(movementOnX, -maxPosition, maxPosition);
        // Calculate the player's movement along the X-axis based on touch input or mouse input
        Vector3 playerMovement = new Vector3(movementOnX, transform.position.y, transform.position.z + Time.deltaTime * playerSpeed);
        // Apply the calculated movement to the player's position
        transform.position = playerMovement;
    }

    public void StopPlayer()
    {
        isPlayerRunning = false;
    }

    public void MovePlayer()
    {
        isPlayerRunning = true;
    }
}
