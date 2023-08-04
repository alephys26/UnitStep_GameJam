using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuttableObjects : MonoBehaviour
{
    public bool harm;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Cut")
        {
            Destroy(gameObject);
            if (harm == true)
            {
                FindObjectOfType<AudioManager>().Play("Stone");
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score -= 10;
                GameObject.Find("PlayersLives").transform.GetComponent<LifeCounter>().LoseLife();
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Slice");
                GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score += 10;
            }
        }

        if (GameObject.Find("ScoreText").transform.GetComponent<ScoreText>().Score == 100)
        {
            GameObject.Find("Sword").transform.GetComponent<Sword_Script>().end = true;
        }
    }
}
