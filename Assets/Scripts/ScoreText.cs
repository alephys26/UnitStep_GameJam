using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    private int score = 0;
    public int Score{
        get{
            return score;
        }
        set{
            score = value;
            GetComponent<TMP_Text>().text = "Score: " + score;
        }
    }
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
