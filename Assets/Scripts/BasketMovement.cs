using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    private Rigidbody2D myBody;
    public float xbound;
    void Start()
    {
        myBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
float h= Input.GetAxisRaw("Horizontal");
        if(h>0){
            myBody.velocity=Vector2.right * 6;
        }else if(h<0){
             myBody.velocity=Vector2.left * 6;
        }else{
             myBody.velocity=Vector2.zero;
        }
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,-xbound,xbound), transform.position.y);
    }
}
