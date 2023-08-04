using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public TMP_Text ScoreText;
    public int _Score = 0;
    public GameObject congratulations;
    public GameObject Boo;
    public GameObject Arr;
    // bool Hit = false;
    void Update()
    {
        if(_Score == 100){
            ScoreText.text=_Score.ToString();
            congratulations.SetActive(true);
            Boo.SetActive(false);
            Arr.SetActive(false);
            
                FindObjectOfType<AudioManager>().Play("Congo");
            StartCoroutine(Loaddelay(3));
        }
        else if(_Score<100){
            ScoreText.text=_Score.ToString();
        }
    }
    IEnumerator Loaddelay(float delay){
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    
}
        