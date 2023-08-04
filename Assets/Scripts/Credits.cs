using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credits : MonoBehaviour
{
    public void exit(){
        Application.Quit();
    }
    public void home(){
        SceneManager.LoadScene("MainScene");   
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainScene");
        }   
    }
}
