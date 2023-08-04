using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFood : MonoBehaviour
{
    public GameObject fruit;
    public GameObject bug;
    public float xBounds, yBound;
    public bool shoulddo=true;
    void Start()
    {   
        StartCoroutine(SpawnRandomGameObject());
    }

    IEnumerator SpawnRandomGameObject(){
        yield return new WaitForSeconds(Random.Range(1,2));
        if(Random.value <= 0.6f){
            Instantiate(fruit, new Vector2(Random.Range(-xBounds,xBounds),yBound),Quaternion.identity);
        }else{
            Instantiate(bug,new Vector2(Random.Range(-xBounds,xBounds),yBound),Quaternion.identity );
        }
        if(shoulddo==true)
        StartCoroutine(SpawnRandomGameObject());
    }
}
