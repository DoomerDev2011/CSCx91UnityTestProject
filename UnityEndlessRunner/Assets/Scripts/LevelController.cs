using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed;
    public float columns;
    private float position;
    public Vector3 scale;
    public Vector3 spawn;
    public Vector3 deSpawn;
    public PlaneController pc;
    public GameObject player;
    public GameObject [] plane = new GameObject[14];
    // Start is called before the first frame update
    void Start()
    {
        
        for(int x = 0; x < columns; x++)
        {
            plane.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>());
            int r = Random.Range(0,13);
            scale = new Vector3(plane.GetComponent<Transform>().localScale.x + scale.x, scale.y, scale.z);
            pc = plane.GetComponent<PlaneController>();
            deSpawn = new Vector3 (player.GetComponent<Transform>().position.x - scale.x * 5.0f, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
            spawn = new Vector3(deSpawn.x + scale.x * 5.0f * columns, deSpawn.y - 1, player.GetComponent<Transform>().position.z);
            Instantiate(plane[r], new Vector3(deSpawn.x + scale.x * 5.0f * (columns - x), deSpawn.y - 1, player.GetComponent<Transform>().position.z), player.GetComponent<Transform>().rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(position < 0)
        {
            pc.Remove();
        }
    }
    public void SpawnPlane()
    {
        plane.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>());
        Instantiate(plane, spawn, player.GetComponent<Transform>().rotation);
    }
    
}
