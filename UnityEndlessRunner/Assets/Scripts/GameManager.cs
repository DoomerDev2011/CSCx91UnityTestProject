using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float timer = 20;
    public float Coins = 0;
    public bool active = false;



    void Update(){
        if (active){
            if(Mathf.Ceil(timer) > 0){
                timer -= Time.deltaTime * 2;
                Debug.Log("Timer: " + Mathf.Ceil(timer));
            }else{
                active = false;
                Time.timeScale = 1f;
                timer = 20;
            }
        }
    } 

}