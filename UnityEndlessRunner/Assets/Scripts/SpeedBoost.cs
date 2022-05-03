
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public float speed;
    public float boosttimer;
    public bool boosting = false;

    void Start() {
        speed = 5;
        boosttimer = 100;
        boosting = false;
    }

 
     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
            this.gameObject.SetActive(false);{
            speed = 10;
            boosttimer -= 1;
            if (boosttimer == 0) {
                boosttimer = 100;
                }
            else boosting = false;
            
            
            }
        }
    
    }

}
