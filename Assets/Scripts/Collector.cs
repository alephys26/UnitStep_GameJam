using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D tar){
        if(tar.tag=="Bug"|| tar.tag=="Mango"){
            Destroy(tar.gameObject);
        }
    }
}
