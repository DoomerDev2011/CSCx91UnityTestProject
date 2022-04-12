using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    public float timer = 60;
    public bool active = false;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            active = true;
            Time.timeScale = 0.5f;
            Debug.Log("Active");
        }
    }

    private void Update(){
        while (active){
            timer -= Time.deltaTime;
            Debug.Log("Timer: " + timer);
            if(timer == 0){
                active = false;
                Time.timeScale = 1f;
                timer = 60;
            }
        }
    }
}