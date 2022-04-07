using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector2 deSpawn;
    public LevelController level;
    public Rigidbody rb;
    public GameObject ground;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        if(gameObject.transform.position.x < deSpawn.x)
        {
            Remove();
        }
    }
    public void SetUp(float movement, Vector2 deSpawnPoint, LevelController levelController)
    {
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
        Vector3 targetVelocity = new Vector2(-speed * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;
    }
}
