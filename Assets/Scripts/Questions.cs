using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    [Header("Questions")]
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [SerializeField] TextMeshProUGUI textQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons = new GameObject[4];

    [Header("Button Collors")]
    [SerializeField] Sprite defaultButtonSprite;
    [SerializeField] Sprite correctButtonSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;
    

   [Header("Slider")]
   [SerializeField] Slider slider;

    bool isAnswerEarly = true;
    public bool isComplete;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();
        slider.maxValue = questions.Count;
        slider.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            isAnswerEarly = false;
            GoToNewQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!timer.isAnsweringQuestion && !isAnswerEarly)
        {
            DisplayAnswer(-1);
            SetButtonsState(false);
        }
    }

    void GoToNewQuestion()
    { 
        if(questions.Count > 0)
            QuestionSelector();

        SetDefaultSprite();
        SetButtonsState(true);
        DisplayQuestion();
        slider.value++;
        isAnswerEarly = false;
    }     

    void QuestionSelector()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion))
            questions.Remove(currentQuestion);
    }

    void DisplayQuestion()
    {
         textQuestion.text = currentQuestion.GetQuestion();
        
        for(int i = 0; i < 4; ++i)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    void SetButtonsState(bool state)
    {
        for(int i = 0; i < 4; ++i)
        {
            Button button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void SetDefaultSprite()
    {
        for(int i = 0; i < 4; ++i)
            answerButtons[i].GetComponent<Image>().sprite = defaultButtonSprite;
    }

    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);
        SetButtonsState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + score.CalculateScore() + '%';
        isAnswerEarly = true;
        
        Debug.Log(slider.value);
        Debug.Log(questions.Count);

        if(questions.Count == 0)
            isComplete = true;
    }
    void DisplayAnswer(int index)
    {
        if(index == currentQuestion.GetCorrectAnswer())
        {
            textQuestion.text = "CORRECT!";
            Image buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctButtonSprite;
            score.CorrectAnswersIncrement();
        }
        else
        {
            textQuestion.text = "Sorry, the correct answer was:\n" + answerButtons[currentQuestion.GetCorrectAnswer()].GetComponentInChildren<TextMeshProUGUI>().text;
            answerButtons[currentQuestion.GetCorrectAnswer()].GetComponent<Image>().sprite = correctButtonSprite;
        }

        score.QuestionsSeenIncrement();
    }
}
