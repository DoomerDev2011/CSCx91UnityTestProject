using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    public float timer = 60;
    public bool active = false;


    private float fixedDeltaTime;


    void OnTriggerEnter(Collider other){
        Debug.Log("made it here");
        if (other.gameObject.tag == "Player"){
            active = true;
            Debug.Log("1");
            Time.timeScale = 0.5f;
            Debug.Log("Active");
        }
    }

    void Update(){
        Debug.Log(active);
        if (active){
            if(timer >= 0){
                timer -= Time.deltaTime;
                Debug.Log("Timer: " + timer);
            }else{
                active = false;
                Time.timeScale = 1f;
                timer = 60;
                // Adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 real-time seconds per frame
                //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
        }
    }
}