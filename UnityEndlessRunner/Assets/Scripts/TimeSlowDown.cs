using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TimeSlowDown : MonoBehaviour {

    public bool active = false;
    private GameManager gm;

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player"){
            active = true;
            Time.timeScale = 0.5f;
            Destroy(this.gameObject);
        }
    }

    void Update(){
        if (active){
            if(Mathf.Ceil(gm.timer) > 0){
                gm.timer -= Time.deltaTime * 2;
                Debug.Log("Timer: " + Mathf.Ceil(gm.timer));
            }else{
                active = false;
                Time.timeScale = 1f;
                gm.timer = 20;
            }
        }
    }
}