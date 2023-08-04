using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dream : MonoBehaviour
{
    private float counter = 0;
    void Start(){
        FindObjectOfType<AudioManager>().Play("Video");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<AudioManager>().Stop("Video");
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            FindObjectOfType<AudioManager>().Stop("Video");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        counter+=Time.deltaTime;
        if (counter>=5){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
