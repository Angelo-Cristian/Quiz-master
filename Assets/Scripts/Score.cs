using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int correctAnswers;
    int questionsSeen;

    public int CorrectAnswersCount()
    {
        return correctAnswers;
    }

    public void CorrectAnswersIncrement()
    {
        correctAnswers++;
    }

    public int QuestionsSeencount()
    {
        return questionsSeen;
    }

    public void QuestionsSeenIncrement()
    {
        questionsSeen++;
    }

    public int CalculateScore()
    {
        return Mathf.RoundToInt(correctAnswers / (float)questionsSeen * 100);
    }
}
