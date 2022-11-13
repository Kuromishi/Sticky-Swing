using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTransit : MonoBehaviour
{
    public GameObject gameOverImage;
    private bool isGameOver;

    //public void YouWin()
    //{

    //}

    public void GameOver()
    {
        if (!gameOverImage.activeSelf)   //get self active state
        {
            gameOverImage.SetActive(true);  
            Time.timeScale = 0;
            isGameOver = true;

        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void StartInterface()
    {
        SceneManager.LoadScene("Start Scene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOver();
        }


    }
}
