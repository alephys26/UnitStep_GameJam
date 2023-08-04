using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    // Destroy da;
    // public Score sc;
    public Vector2 direction;
    // Start is called before the first frame update
   // public float force;
    // public GameObject PointPrefab;
    // public GameObject[] Points;
    // public int numberofPoints;
    void Start()
    { 
    //   da = GetComponent<Destroy>();  
    //   Points = new GameObject[numberofPoints];
    //   for (int i = 0; i < numberofPoints; i++)
    //   {
    //         Points[i] = Instantiate(PointPrefab,transform.position,Quaternion.identity);
    //   } 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 BowPosition = transform.position;
        direction = MousePos - BowPosition;
        FaceMouse();
        // for (int i = 0; i < Points.Length; i++)
        // {
        //     Points[i].transform.position = PointPosition(i*0.1f);
        // }
        // da.DestroyPoint();
    }
    void FaceMouse()
    {
        transform.right = direction;
    }

    // Vector2 PointPosition(float t){
    //     Vector2 CurrentPointpos = (Vector2)transform.position + (direction.normalized*force*t) +0.5f*Physics2D.gravity*(t*t);
    //     return CurrentPointpos; 
    // }

}
