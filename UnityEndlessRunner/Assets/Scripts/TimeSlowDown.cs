using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {
    public int timer = 100;
    void Update() {
        void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            timer -= 1;
            if (timer == 0) {
                timer = 100;
                OnTriggerEnter = false;
                }
            else Time.timeScale = 0.5f;
        
            }


        }

    }

}
