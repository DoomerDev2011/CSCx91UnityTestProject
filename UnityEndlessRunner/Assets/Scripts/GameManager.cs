using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{  
    /*make some public variables to keep the ability scripts*/
    public static GameManager instance;
    /*Coin script*/
    public float Coins = 0;
    /*TimeSlowDown script*/
    public float slowtimer = 10;
    public bool slowing = false;
    /*SpeedBoost script*/
    public float speed;
    public float boosttimer = 10;
    public bool boosting = false;



    /*make the updata during the game*/
    void Update(){
        /*when the boosting is true*/
        if (boosting){
            /*if the variable boosttimer greater then 0*/
            if(Mathf.Ceil(boosttimer)>0){
                /*if the variable slowing also true*/
                if(slowing){
                    boosttimer -= Time.deltaTime*2;/*the variable boosttimer*/
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
        if (slowing){
            if(Mathf.Ceil(slowtimer) > 0){
                slowtimer -= Time.deltaTime * 2;
                Debug.Log("Timer: " + Mathf.Ceil(slowtimer));
            }else{
                slowing = false;
                Time.timeScale = 1f;
                slowtimer = 10;
            }
        }
    } 

}