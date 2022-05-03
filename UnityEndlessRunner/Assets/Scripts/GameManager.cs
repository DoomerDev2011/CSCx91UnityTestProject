using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float slowtimer = 20;
    public float Coins = 0;
    public bool active = false;



    void Update(){
        if (active){
            if(Mathf.Ceil(slowtimer) > 0){
                slowtimer -= Time.deltaTime * 2;
                Debug.Log("Timer: " + Mathf.Ceil(slowtimer));
            }else{
                active = false;
                Time.timeScale = 1f;
                slowtimer = 20;
            }
        }
    } 

}