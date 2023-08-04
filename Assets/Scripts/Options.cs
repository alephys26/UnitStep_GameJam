using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject img1; 
    public GameObject img2;
    public string mus1=null;
    public string mus11=null;
    public string mus2=null;
    public string mus3=null;
    public float limit1, limit2;
    private float counter=0;
    void Update(){
        counter+=Time.deltaTime;
        if(counter>=2 && counter<=limit1){
            if(mus1!=null){
                FindObjectOfType<AudioManager>().Play(mus1);
                mus1=null;
            }
            if(mus11!=null){
                FindObjectOfType<AudioManager>().Play(mus11);
                mus11=null;
            }
            img1.SetActive(true);
        }
        else if(counter>limit1 && counter<limit2){
            img2.SetActive(true);
            img1.SetActive(false);
            if(mus2!=null){
                FindObjectOfType<AudioManager>().Play(mus2);
                mus2=null;
            }
        }
        else if(counter>=limit2){
            if(mus3!=null){
                FindObjectOfType<AudioManager>().Play(mus3);
                Loaddelay(4);
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }else{
        }
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(img1.activeSelf==true && img2.activeSelf==false){
                counter=limit1;
            }else if(img2.activeSelf==true && img1.activeSelf==false){
                counter=limit2;
            }
        }else if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene("MainScene");
        }
    }
    IEnumerator Loaddelay(float delay){
        yield return new WaitForSeconds(delay);
    }
}
