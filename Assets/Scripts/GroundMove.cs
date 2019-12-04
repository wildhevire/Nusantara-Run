using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{

    Ground ground;
    // Start is called before the first frame update
    void Start()
    {
        ground = GetComponentInParent<Ground>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.left * 5 * Time.deltaTime;
    }
}
