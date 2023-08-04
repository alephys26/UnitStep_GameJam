using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreBasket : MonoBehaviour
{
    private int lives = 3;
    private int score = 0;
    public GameObject scorepanel;
    public GameObject win;
    public GameObject lose;
    public SpawnerFood sp;

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Bug") == true)
        {
            lives--;
            if (lives <= 0)
            {
                scorepanel.SetActive(true);
                if (score >= 10)
                {
                    FindObjectOfType<AudioManager>().Play("Congo");
                    win.SetActive(true);
                    sp.shoulddo = false;
                    StartCoroutine(Loaddelay(3));
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Lose");
                    lose.SetActive(true);
                    sp.shoulddo = false;
                    StartCoroutine(Loadsamedelay(3));
                }
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Eat");
            }
        }
        else if (target.tag == "Mango")
        {
            Destroy(target.gameObject);
            score++;
            if (score >= 10)
            {
                FindObjectOfType<AudioManager>().Play("Congo");
                scorepanel.SetActive(true);
                win.SetActive(true);
                sp.shoulddo = false;
                StartCoroutine(Loaddelay(3));
            }
            FindObjectOfType<AudioManager>().Play("Drop");
        }
    }

    void OnTriggerExit2D(Collider2D target)
    {
        if (target.tag == "Bug" || target.tag == "Mango")
        {
            Destroy(target.gameObject);
        }
    }

    IEnumerator Loaddelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Destroy(gameObject);
    }

    IEnumerator Loadsamedelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Instructions 2");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
