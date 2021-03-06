using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector3 deSpawn;
    public LevelController level;
    public Rigidbody rb;
    public RunnerControl player;
    public GameObject ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        if(gameObject.transform.position.z < deSpawn.z)
        {
            Remove();
        }
        if (player.gameOver)
        {
            speed = 0;
        }
    }
    public void SetUp(float movement, Vector3 deSpawnPoint, LevelController levelController, RunnerControl play)
    {
        player = play;
        speed = movement;
        deSpawn = deSpawnPoint;
        level = levelController;
    }
    public void Remove()
    {
        level.SpawnPlane();
        Destroy(gameObject);
    }
    public void Move()
    {
        Vector3 targetVelocity = new Vector3(0f, 0f, -speed * 10f);
        rb.velocity = targetVelocity;
    }
}
