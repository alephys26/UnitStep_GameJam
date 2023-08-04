using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sword_Script : MonoBehaviour
{
    public GameObject cutPrefab;
    public float cutLife;
    private bool drag;
    private Vector2 SwipeStart;
    public bool end = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            drag = true;
            SwipeStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0) && drag)
        {
            drag = false;
            SpawnCut();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
        if (end == true)
        {
            GameObject.Find("ScoreText").SetActive(false);
            GameObject.Find("Mud_Ball_Spawn").SetActive(false);
            GameObject.Find("Stone_Spawn").SetActive(false);
            FindObjectOfType<AudioManager>().Play("Congo");
            GameObject.Find("Score").transform.Find("Congo").gameObject.SetActive(true);
            StartCoroutine(Loaddelay(3));
        }
    }

    IEnumerator Loaddelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SpawnCut()
    {
        Vector2 SwipeEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject cutInstance = Instantiate(cutPrefab, SwipeStart, Quaternion.identity);
        cutInstance.GetComponent<LineRenderer>().SetPosition(0, SwipeStart);
        cutInstance.GetComponent<LineRenderer>().SetPosition(1, SwipeEnd);
        FindObjectOfType<AudioManager>().Play("Slash");
        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = Vector2.zero;
        colliderPoints[1] = SwipeEnd - SwipeStart;
        cutInstance.GetComponent<EdgeCollider2D>().points = colliderPoints;
        Destroy(cutInstance, cutLife);
    }
}
