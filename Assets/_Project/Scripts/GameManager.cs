using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject winPanel;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject player;
    private bool gameEnded = false;

    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    void Update()
    {
        if (gameEnded) return;

        if (player == null)
        {
            GameOver();
            return;
        }

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Victory();
        }

        
    }

    void Victory()
    {
        gameEnded = true;
        winPanel.SetActive(true);
        if (player != null)
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = false;
            }
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    void GameOver()
    {
        gameEnded = true;
        losePanel.SetActive(true);
        if (player != null)
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            if (controller != null)
            {
                controller.enabled = false;
            }
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
