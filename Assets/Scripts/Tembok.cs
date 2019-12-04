using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tembok : MonoBehaviour
{
    Ground ground;
    [SerializeField] GameObject tembokPrefab;
    [SerializeField] GameObject groundGO;
    public float tembokDuration;

    public List<GameObject> tembokList = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        ground = groundGO.GetComponent<Ground>();
        tembokDuration = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
        tembokDuration -= Time.deltaTime;
        
        if (tembokDuration <= 0)
        {

            GameObject tembok = Instantiate(tembokPrefab,transform);
            tembokList.Add(tembok);
            tembokDuration = Random.Range(2,5);

            foreach (GameObject tembok1 in tembokList)
            {
                //tembok1.transform.position += Vector3.left * ground.speed * Time.deltaTime;
            }
        }

        
    }
}
