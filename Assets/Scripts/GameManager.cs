using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    Questions quiz;
    EndScreen endScreen;

    void Start()
    {
        quiz = FindObjectOfType<Questions>();
        endScreen = FindObjectOfType<EndScreen>();

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
    }

    void Update()
    {
        if(quiz.isComplete)
        {
            endScreen.FinalText();
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
           
        } 
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
