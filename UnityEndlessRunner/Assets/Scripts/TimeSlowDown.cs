using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    public float timer = 60;
    public bool active = false;


    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }


    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Player"){
            active = true;
            Time.timeScale = 0.5f;
            Debug.Log("Active");
        }
    }

    private void Update(){
        while(active){
            timer -= Time.fixedDeltaTime;
            Debug.Log("Timer: " + timer);
            if(timer == 0){
                active = false;
                Time.timeScale = 1f;
                timer = 60;
                // Adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 real-time seconds per frame
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
        }
    }
}