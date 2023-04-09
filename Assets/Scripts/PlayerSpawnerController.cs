using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] GameObject playerPrefab;
    // Variable to control the speed of player movement
    float xSpeed;
    // Specify the maximum position on the X-axis
    float maxPosition = 4.10f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer(5);
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
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

    public void SpawnPlayer(int playerCount)
    {
        for (int i = 0; i < playerCount; i++)
        {
            // Instantiate the player prefab at the specified spawn position
            GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
        }
    }
    
    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}
