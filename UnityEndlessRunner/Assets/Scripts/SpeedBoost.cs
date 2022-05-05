
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    private GameManager gm;

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

 
     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
             gm.speed += 5;
             gm.boosting = true;
             Destroy(this.gameObject); 
         }
         /*if (other.gameObject.tag == "Player"){
            this.gameObject.SetActive(false);{
            speed = 10;
            boosttimer -= 1;
            if (boosttimer == 0) {
                boosttimer = 100;
                }
            else boosting = false;
            
            
            }
        }*/
    
    }

}
