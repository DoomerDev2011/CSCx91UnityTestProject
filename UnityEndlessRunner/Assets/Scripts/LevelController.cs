using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed;
    public float columns;
    private float position;
    public Vector3 scale;
    public Vector2 spawn;
    public Vector2 deSpawn;
    public PlaneController pc;
    public GameObject player;
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        scale = plane.GetComponent<Transform>().lossyScale;
        pc = plane.GetComponent<PlaneController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(position < 0)
        {
            pc.Remove();
        }
    }
    
}
