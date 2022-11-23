using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startscreen : MonoBehaviour
{
    public GameObject guidePic;
    private bool isPaused;

    private void Start()
    {
        Time.timeScale = 1;
        guidePic.SetActive(false);
        isPaused = false;
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


    public void GuideGame()
    {
        // get the active state of the guide picture
        if (guidePic.activeSelf)    //if the guidePic is shown == the checkbox in inspector is ¡Ì
        {
            guidePic.SetActive(false); 
            Time.timeScale = 1;   //normal
            isPaused = false;
        }

        else if (!guidePic.activeSelf)
        {
            guidePic.SetActive(true);
            Time.timeScale = 0;   //pause the game
            isPaused = true;
        }
    }
}

