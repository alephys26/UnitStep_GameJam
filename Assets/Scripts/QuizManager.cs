using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public int score = 0;
    public TMP_Text QuestionTxt;
    public TMP_Text ScoreTxt;
    public GameObject scorepanel;
    public GameObject win;
    public GameObject lose;
    public GameObject quizpanel;

    private void Start()
    {
        generateQuestion();
    }

    void GameOver()
    {
        quizpanel.SetActive(false);
        scorepanel.SetActive(true);
        ScoreTxt.text = score.ToString() + "/ 5";
        if (score == 5)
        {
            win.SetActive(true);
            StartCoroutine(Loaddelay(3));
        }
        else
        {
            lose.SetActive(true);
            StartCoroutine(Loadsamedelay(3));
        }
    }

    public void correct()
    {
        score += 1;
        FindObjectOfType<AudioManager>().Play("Congo");
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    IEnumerator Loaddelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void wrong()
    {
        FindObjectOfType<AudioManager>().Play("Lose");
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    IEnumerator Loadsamedelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[
                currentQuestion
            ].Answer[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 25)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            GameOver();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Instructions 1");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
