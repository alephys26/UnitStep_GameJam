using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfLives;
    public GameObject lifePrefab;
    public GameObject scoreText;
    public GameObject scorepanel;
    public GameObject lose;
    private List<GameObject> lives;

    void Start()
    {
        lives = new List<GameObject>();
        for (int i = 0; i < numberOfLives; i++)
        {
            GameObject lifeInstance = Instantiate(lifePrefab, transform);
            lives.Add(lifeInstance);
        }
    }

    public void LoseLife()
    {
        numberOfLives--;
        GameObject Lastlife = lives[lives.Count - 1];
        lives.Remove(Lastlife);
        Destroy(Lastlife);
        if (numberOfLives <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Lose");
            scoreText.SetActive(false);
            GameObject.Find("Mud_Ball_Spawn").SetActive(false);
            GameObject.Find("Stone_Spawn").SetActive(false);
            scorepanel.SetActive(true);
            lose.SetActive(true);
            StartCoroutine(Loadsamedelay(3));
        }
    }

    IEnumerator Loadsamedelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
