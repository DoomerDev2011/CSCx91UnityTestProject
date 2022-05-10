
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private GameManager gm; // GameManager Reference

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

 
     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
             gm.speed += 5; // Increase the speed
             gm.boosting = true;
             Destroy(this.gameObject); 
         }
    
    }

}
