using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public float interval;
    public float minX;
    public float maxX;
    public float y;
    public Sprite[] sprites;

    void Start()
    {
     InvokeRepeating("Spawn",interval,interval);   
    }
    private void Spawn(){
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            Random.Range(minX,maxX),
            y
        );
        instance.transform.SetParent(transform);
        Sprite randomSprite = sprites[Random.Range(0,sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
