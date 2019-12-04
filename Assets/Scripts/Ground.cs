using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// tembok = (6.5, 1.2)
/// </summary>
public class Ground : MonoBehaviour
{
    [SerializeField]  GameObject groundPrefab;

    [SerializeField] GameObject ground;
    [SerializeField] GameObject hole;
    [SerializeField] GameObject tembok;
    public GameObject[] groundList = new GameObject[7];

    GameObject currentEnteredObject;
    public float speed = 5f;


    float  endX = -13.5f;
    float startX = 8.5f;


    float startGround = 12.09f;
    float endGround = -16.79f;

    float startTembok = 7.72f;
    float endTembok = -12.23f;

    float startHole = 11.84f;
    float endHole = -10.42f;


    [SerializeField] float offsetLubang =5f;

    [SerializeField] [Range(0, 100)] int probabilityLubang = 15;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

        
        //for(int i = 0; i <= 11; i++)
        //{
        //    GameObject ground = Instantiate(groundPrefab, new Vector3(endX + (2 * i), -5), Quaternion.identity, transform);
        //    groundList.Add(ground);
        //}
        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (groundList[0].transform.localPosition.x <= endX)
        {
            //groundList[0].transform.localPosition = new Vector3(startX, -1f);
            arraySwap(groundList);
        }


        //Debug.Log(groundList.Length);
        //if (tembok.transform.localPosition.x <= endX || hole.transform.localPosition.x <= endX || ground.transform.localPosition.x <= endX)
        //{

        //    var random = Random.Range(0, 100);
        //    if(random <= 15) // tembok
        //    {
        //        tembok.transform.localPosition =  new Vector3(startX, -1f);
        //        //currentEnteredObject = tembok;
        //    }
        //    else if (random > 15 && random <= 30) // hole
        //    {
        //        hole.transform.localPosition =  new Vector3(startX, -1f);
        //        //currentEnteredObject = hole;
        //    } else if (random > 30 ) //ground
        //    {
        //        ground.transform.localPosition =  new Vector3(startX, -1f);
        //        //currentEnteredObject = ground;
        //    }
        //}




        //for (int i = 0; i < 4; i++)
        //{
        //    //groundList[i].transform.position += Vector3.left * speed * Time.deltaTime;

        //    if (groundList[i].transform.position.x <= endX)
        //    {
        //        groundList[i].transform.position = new Vector3(startX, -5f);
        //        var random = Random.Range(0, 100);
        //        if (random < probabilityLubang)
        //        {
                    
        //            groundList[i].transform.position = new Vector3(startX + offsetLubang, -5f);
        //            groundList[i-1].transform.position = new Vector3(groundList[i-1].transform.position.x + startX, -5f);
        //            if(i == 0) { break; }
                    
        //        }

        //    }
        //}

        //for (int i = 0; i < 4; i++)
        //{

        //}
            //foreach (GameObject ground in groundList)
            //{
            //    ground.transform.position += Vector3.left * speed * Time.deltaTime;
            //    if (ground.transform.position.x <= endX)
            //    {
            //        ground.transform.position = new Vector3(startX, -5f);
            //        var random = Random.Range(0, 100);
            //        if (random < probabilityLubang)
            //        {
            //            ground.transform.position = new Vector3(startX + 8f, -5f);
            //        }
            //    }


            //}





        }
    //1 - 2
    //2 - 3
    //3- 4
    //4 - 5
    //5 - 1
    void arraySwap(GameObject[] arr)
    {

        GameObject something = null;
        var random = Random.Range(0, 100);
        if (random <= 15)
        {
            something = tembok;
            //currentEnteredObject = tembok;
        }
        else if (random > 15 && random <= 30) // hole
        {
            something = hole;
            //currentEnteredObject = hole;
        }
        else if (random > 30) //ground
        {
            something = ground;
            //currentEnteredObject = ground;
        }
        GameObject tmp = Instantiate(something,position: new Vector3(startX, -1), Quaternion.identity);
        for (int i = 0; i <= arr.Length -1 ; i++)
        {
            if(i < arr.Length - 1) 
                arr[i] = arr[i + 1];
            else
            arr[arr.Length-1] = tmp;
            
        }
        
    }



}

