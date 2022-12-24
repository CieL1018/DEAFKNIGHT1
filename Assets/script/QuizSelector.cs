using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizSelector : MonoBehaviour
{
    public GameObject currentScreen;
    public GameObject correctScreen, wrongScreen;

    public void wrongAnswer()
    {
        wrongScreen.SetActive(true);
        currentScreen.SetActive(false);
    }

    public void correctAnswer()
    {
        currentScreen.SetActive(false);
        correctScreen.SetActive(true);
    }

}
