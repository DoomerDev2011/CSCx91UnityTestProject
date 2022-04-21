using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    public float timer = 20;
    public bool active = false;

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            active = true;
            Time.timeScale = 0.5f;
        }
    }

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