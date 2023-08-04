using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    Destroy Da;
    Rigidbody2D rb;

    // Start is called before the first frame update
    bool Hit = false;
    public Score score;
    public GameObject con;
    public GameObject b;
    public GameObject a;
    public GameObject c1,
        c2,
        c3,
        c4,
        c5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Da = GetComponent<Destroy>();
        score.congratulations = con;
        score.Boo = b;
        score.Arr = a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hit == false)
        {
            rb.gravityScale = 1;
            Trajectory();
            // Collision();
            Da.DestroyArrow(1.8f);
        }
        else
        {
            rb.gravityScale = 0.0f;
            Da.DestroyArrow(0.0f);
        }
    }

    void Trajectory()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Hit = true;
        if (col.gameObject.name == "Circle")
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(true);

            FindObjectOfType<AudioManager>().Play("Hit");
            score._Score += 10;
        }
        else if (col.gameObject.name == "Circle (1)")
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(true);
            c5.SetActive(false);

            FindObjectOfType<AudioManager>().Play("Hit");
            score._Score += 10;
        }
        else if (col.gameObject.name == "Circle (2)")
        {
            c1.SetActive(false);
            c2.SetActive(true);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);

            FindObjectOfType<AudioManager>().Play("Hit");
            score._Score += 10;
        }
        else if (col.gameObject.name == "Circle (3)")
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
            c4.SetActive(false);
            c5.SetActive(false);

            FindObjectOfType<AudioManager>().Play("Hit");
            score._Score += 10;
        }
        else if (col.gameObject.name == "Circle (4)")
        {
            c1.SetActive(true);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);

            FindObjectOfType<AudioManager>().Play("Hit");
            score._Score += 10;
        }
    }
}
