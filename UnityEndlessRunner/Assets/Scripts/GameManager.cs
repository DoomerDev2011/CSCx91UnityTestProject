using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float Coins = 0;
    public float slowtimer = 10;
    public bool active = false;
    public float speed;
    public float boosttimer = 10;
    public bool boosting = false;




    void Update(){
        if (boosting){
            if(Mathf.Ceil(boosttimer)>0){
                if(active){
                    boosttimer -= Time.deltaTime*2;
                }else{
                    boosttimer -= Time.deltaTime;
                }
                Debug.Log("Boosting: " +Mathf.Ceil(boosttimer));
            }else{
                boosting = false;
                speed -= 5;
                boosttimer = 10;
            }
        }
        if (active){
            if(Mathf.Ceil(slowtimer) > 0){
                slowtimer -= Time.deltaTime * 2;
                Debug.Log("Timer: " + Mathf.Ceil(slowtimer));
            }else{
                active = false;
                Time.timeScale = 1f;
                slowtimer = 10;
            }
        }
    } 

}