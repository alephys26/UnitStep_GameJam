using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text remarrow;
    public TMP_Text score;
    public float LaunchForce;
    public GameObject Arrow;
    public GameObject lose;
    public GameObject Deactivebow;
    public GameObject Deactivearr;
    static Vector3 ps;
    static Vector3 rt;
    public int count = 0;

    void Start()
    {
        ps = transform.position;
        rt = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        LaunchForce = Vector2.Distance(
            transform.position,
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );
        if (count < 14)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                count++;
                ShootArrow();
            }
            remarrow.text = (14 - count).ToString();
        }
        else if (count == 14)
        {
            Arrow.SetActive(false);
            if (score.text == "90")
            {
                StartCoroutine(ploywork());
            }
            else if (score.text != "100")
            {
                imptask();
            }
            Deactivearr.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void imptask()
    {
        if (score.text != "100")
        {
            FindObjectOfType<AudioManager>().Play("Lose");
            lose.SetActive(true);
            StartCoroutine(Loaddelay(3));
        }
    }

    IEnumerator ploywork()
    {
        yield return new WaitForSeconds(2);
        imptask();
    }

    IEnumerator Loaddelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Deactivebow.SetActive(false);
        SceneManager.LoadScene("MainScene");
    }

    void ShootArrow()
    {
        GameObject ArrowIns = Instantiate(Arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().velocity = (transform.right) * LaunchForce * 6 / 5;
        FindObjectOfType<AudioManager>().Play("Shoot");
    }
}
