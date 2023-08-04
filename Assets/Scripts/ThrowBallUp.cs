using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBallUp : MonoBehaviour
{
    // Start is called before the first frame update
    public float miniXspeed,miniYspeed,maxXspeed,maxYspeed;
    public float life;
    void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(miniXspeed,maxXspeed),
            Random.Range(miniYspeed,maxYspeed)
        );
        Destroy(gameObject,life);
    }

}
