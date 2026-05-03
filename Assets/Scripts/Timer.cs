using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float time;
    public float fillFraction;
    [SerializeField] float answerQuestionTimer = 30f;
    [SerializeField] float waitTimer = 10f;
    public bool isAnsweringQuestion;
    public bool loadNextQuestion;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }
    
    public void CancelTimer()
    {
        time = 0f;
    }

    void UpdateTimer()
    {
        time -= Time.deltaTime;

        if(time <= 0)
        {
            if(isAnsweringQuestion == false)
            {
                time = answerQuestionTimer;
                isAnsweringQuestion = true;
                loadNextQuestion = true;
            }
            else
            {
                time = waitTimer;
                isAnsweringQuestion = false;
            }
        }
        else if(time > 0 && isAnsweringQuestion == true)
        {
            fillFraction = time / answerQuestionTimer;
        }
        else
        {
            fillFraction = time / waitTimer;
        }
    }
}
