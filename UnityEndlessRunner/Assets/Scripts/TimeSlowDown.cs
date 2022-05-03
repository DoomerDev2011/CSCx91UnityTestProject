using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    private GameManager gm;

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            gm.active = true;
            Time.timeScale = 0.5f;
            Destroy(this.gameObject);
        }
    }

    
}