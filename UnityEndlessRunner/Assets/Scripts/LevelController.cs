using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public float speed;
    public float columns;
    private float position;
    public int last;
    public Vector3 scale;
    public Vector3 spawn;
    public Vector3 deSpawn;
    public PlaneController pc;
    public GameObject player;
    public GameObject ground;
    public GameObject[] plane;
    // Start is called before the first frame update
    void Start()
    {
        last = -1;
        float length = 0;
        for (int x = 0; x < columns; x++)
        {

            int r = Random.Range(0, plane.Length);
            while (r == last)
            {
                r = Random.Range(0, plane.Length);
            }
            GameObject planeObj = plane[r];
            Debug.Log(r);
            Debug.Log(planeObj.gameObject.name);
            pc = planeObj.GetComponent<PlaneController>();
            ground = pc.ground;
            scale = ground.GetComponent<Transform>().lossyScale;
            length += scale.z;
            deSpawn = new Vector3(player.GetComponent<Transform>().position.x - scale.z, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
            planeObj.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>());
            Instantiate(planeObj, new Vector3(deSpawn.x + length, deSpawn.y - 1, player.GetComponent<Transform>().position.z), Quaternion.Euler(0, 90 + planeObj.GetComponent<Transform>().rotation.eulerAngles.y, 0));
            last = r;
            spawn = new Vector3(deSpawn.x + length, deSpawn.y - 1, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (position < 0)
        {
            pc.Remove();
        }
    }
    public void SpawnPlane()
    {
        int r = Random.Range(0, plane.Length);

        while (r == last) {
            r = Random.Range(0, plane.Length);
        }

        GameObject planeObj = plane[r];
        planeObj.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>());
        Instantiate(planeObj, spawn, Quaternion.Euler(0, 90 + planeObj.GetComponent<Transform>().rotation.eulerAngles.y, 0));
        last = r;
    }
}