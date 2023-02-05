using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizSelector : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject correctScreen, wrongScreen;

    public void wrongAnswer()
    {
        currentScreen.SetActive(false);
        wrongScreen.SetActive(true);
    }

    public void correctAnswer()
    {
        currentScreen.SetActive(false);
        correctScreen.SetActive(true);
    }
    public void resumeGame() 
    {
        currentScreen.SetActive(false);
        correctScreen.SetActive(false);
        wrongScreen.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        // isPaused = false;
    }

}
