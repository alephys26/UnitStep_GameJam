using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswersScript : MonoBehaviour
{
    public bool isCorrect= false;
    public QuizManager quizManager;

    public void Answer()
    {
        if(isCorrect)
        {
            quizManager.correct();
        }
        else
        {
            quizManager.wrong();
        }
    }
}
