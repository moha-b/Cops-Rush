using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance; // Singleton instance

    public GameObject menuPanel;  // Reference to the menu panel game object
    public GameObject failPanel;  // Reference to the fail panel game object
    public GameObject winPanel;   // Reference to the win panel game object

    // Public method to access the Singleton instance
    public static GameManager Instance
    {
        get { return instance; }
    }

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // If the instance is already set and it's not this instance, destroy this duplicate instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Set the instance to this instance
        instance = this;

        // Make this game object persist across scene loads
        //DontDestroyOnLoad(this.gameObject);
    }

    // Method to start the game
    public void StartGame()
    {
        menuPanel.SetActive(false);
        PlayerMovement playerMovement = GameObject.Find("Player Spawner").GetComponent<PlayerMovement>();
        playerMovement.MovePlayer(); 
    }

    // Method to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene("Level-1"); 
    }

    // Method to show the fail panel
    public void ShowFailPanel()
    {
        failPanel.SetActive(true);
    }
    // Method to show the fail panel
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }
}
