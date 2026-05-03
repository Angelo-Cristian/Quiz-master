using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI finalScore;
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FinalText()
    {
        score = FindObjectOfType<Score>();
        finalScore.text = "Congratulations!\nYour final score is " + score.CalculateScore() + '%';
    }
}
