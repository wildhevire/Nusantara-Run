using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] GameObject itemPrefab;

    float tembokDuration=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        tembokDuration -= Time.deltaTime;
        if (tembokDuration <= 0)
        {

            //GameObject tembok = Instantiate(itemPrefab, new Vector3(s));
            //rb.velocity += Vector2.left * 5 * Time.deltaTime; 
            tembokDuration = Random.Range(1, 4);


        }

    }

}
