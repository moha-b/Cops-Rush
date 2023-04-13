using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> playerList;
    [SerializeField] float playerSpeed = 5f;
    // Variable to control the speed of player movement
    float xSpeed;
    // Specify the maximum position on the X-axis
    float maxPosition = 4.10f;

    bool isPlayerRunning;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isPlayerRunning)
        {
            return;
        }
        PlayerMovements();
    }

    void PlayerMovements()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            isPlayerRunning = true;
            GameManager.Instance.ShowWinPanel();
        }
    }

    public void EnemyDetected(GameObject enemy)
    {
        isPlayerRunning = true;
        LookAtEnemy(enemy);
        StartShooting();
    }

    private void LookAtEnemy(GameObject enemy)
    {
        Vector3 direction = enemy.transform.position - transform.position;
        Quaternion lookAt = Quaternion.LookRotation(direction);
        lookAt.x = 0;
        lookAt.z = 0;

        transform.rotation = lookAt;
    }

    public void Spawn(int gateValue,GateType gateType)
    {
        if (gateType == GateType.ADDITION)
        {
            for (int i = 0; i < gateValue; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                playerList.Add(playerInstance);
            }
        }
        else if(gateType == GateType.MULTIPLY)
        {
            Debug.Log("Inside");
            int playerCount = (playerList.Count * gateValue) - playerList.Count;
            for (int i = 0; i < playerCount; i++)
            {
                // Instantiate the player prefab at the specified spawn position
                Debug.Log("Instantiate");
                GameObject playerInstance = Instantiate(playerPrefab, GetPlayerPosition(), Quaternion.identity, transform);
                Debug.Log("Expand The List");
                playerList.Add(playerInstance);
            }
        }
        
    }

    public void KillCop(GameObject cop)
    {
        playerList.Remove(cop);
        Destroy(cop);
        DetectCopCount();
    }

    public void AllZomibesKilled()
    {
        LookForward();
        MovePlayer();
    }

    private void DetectCopCount()
    {
        if (playerList.Count <= 0)
        {
            StopPlayer();
            GameManager.Instance.ShowFailPanel();
        }
    }

    private void StopPlayer()
    {
        isPlayerRunning = true;
    }

    public void MovePlayer()
    {
        isPlayerRunning = false;
        StartRunning();
    }

    private void LookForward()
    {
        transform.rotation = Quaternion.identity;
    }

    private void StartShooting()
    {
        for(int i = 0;i < playerList.Count;i++)
        {
            PlayerController cop = playerList[i].GetComponent<PlayerController>();
            cop.StartShooting();
        }
    }
    private void StartRunning()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            PlayerController cop = playerList[i].GetComponent<PlayerController>();
            cop.StartRunning();
        }
    }

    public Vector3 GetPlayerPosition()
    {
        Vector3 position = Random.insideUnitSphere * 0.1f;
        Vector3 newPosition = position + transform.position;
        return newPosition;
    }
}
