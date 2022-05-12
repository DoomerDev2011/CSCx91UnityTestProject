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
        float length = 5;
        for (int x = 0; x < columns; x++)
        {
            if(x == 0)
            {
                GameObject obj = plane[0];
                pc = plane[0].GetComponent<PlaneController>();
                ground = pc.ground;
                scale = ground.GetComponent<Transform>().lossyScale;
                length += scale.z;
                deSpawn = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z - scale.z);
                plane[0].GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>(), player.GetComponent<RunnerControl>());
                Instantiate(plane[0], new Vector3(player.GetComponent<Transform>().position.x, deSpawn.y - 1, deSpawn.z + length), Quaternion.Euler(0, plane[0].GetComponent<Transform>().rotation.eulerAngles.y, 0));
                last = 0;
                spawn = new Vector3(deSpawn.x, deSpawn.y - 1, deSpawn.z + length);
                continue;
            }
            int r = Random.Range(0, plane.Length);
            while (r == last)
            {
                r = Random.Range(0, plane.Length);
            }
            GameObject planeObj = plane[r];
            //Debug.Log(r);
            //Debug.Log(planeObj.gameObject.name);
            pc = planeObj.GetComponent<PlaneController>();
            ground = pc.ground;
            scale = ground.GetComponent<Transform>().lossyScale;
            length += scale.z;
            deSpawn = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z - scale.z);
            planeObj.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>(),player.GetComponent<RunnerControl>());
            Instantiate(planeObj, new Vector3(player.GetComponent<Transform>().position.x, deSpawn.y - 1, deSpawn.z + length), Quaternion.Euler(0, planeObj.GetComponent<Transform>().rotation.eulerAngles.y, 0));
            last = r;
            spawn = new Vector3(deSpawn.x, deSpawn.y - 1, deSpawn.z + length);
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
        planeObj.GetComponent<PlaneController>().SetUp(speed, deSpawn, gameObject.GetComponent<LevelController>(), player.GetComponent<RunnerControl>());
        Instantiate(planeObj, spawn, Quaternion.Euler(0, planeObj.GetComponent<Transform>().rotation.eulerAngles.y, 0));
        last = r;
    }
}