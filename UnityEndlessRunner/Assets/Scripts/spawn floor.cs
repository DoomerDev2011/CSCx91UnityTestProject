using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    //basic array for storing tiles currently spawned 
    //9 tiles ahead and 1 tile behind 
    GameObject [10] tiles = GameObject.FindGameObjectsWithTag("Tile");




    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(10, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3();
    }
}
