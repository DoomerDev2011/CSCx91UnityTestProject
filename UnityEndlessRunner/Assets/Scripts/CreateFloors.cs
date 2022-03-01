using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloors : MonoBehaviour{
    public GameObject [] prefabs= new GameObject[14];
    public GameObject player;

    void Start()
    {
        int r = Random.Range(0,13);
        
        Instantiate(prefabs[r], new Vector3(0, 0, player.transform.position.z +32), Quaternion.identity);
    }


    // Update is called once per frame
    void Update(){
        // spawn a tile after the player hits 15 units 
        if(player.transform.position.z > 15){
            int r = Random.Range(0,13);
            Instantiate(prefabs[r], new Vector3(0, 0, player.transform.position.z +22), Quaternion.identity);
        }
    }
}
