using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public void DestroyArrow(float del){
        if (gameObject.name == "ARROW(Clone)")
        {
            Destroy(gameObject, del);
        }
    }
//     public void DestroyPoint(){
//         if (gameObject.name == "Point(Clone)")
//         {
//             Destroy(gameObject, 0.5f);
//         }
//     }
}
