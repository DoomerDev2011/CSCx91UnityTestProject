using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{

    public Collider obstacle;
    public bool isWall;
    public bool isItem;
    public LayerMask layer;
    // Start is called before the first frame update
    void Start()
    {

    }
    

// Update is called once per frame
void Update()
    {
        Collider[] hitRange = Physics.OverlapBox(obstacle.transform.position,obstacle.transform.lossyScale/2, Quaternion.Euler(0,0,0), layer);
        for (int i = 0; i < hitRange.Length; i++)
        {
            if (hitRange[i] != gameObject) {
                if (isWall)
                {
                    Debug.Log(gameObject.name);
                    hitRange[i].GetComponent<RunnerControl>().Die();
                    isWall = false;
                }
                else if (isItem)
                {
                    hitRange[i].GetComponent<RunnerControl>().UseItem();
                }

            }
        }
    }
}
