using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toQuiz : MonoBehaviour
{
    public GameObject pic;
    public static bool isPaused;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        pic.SetActive(true);
        PauseGame();
    }
    
}
