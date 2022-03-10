using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour {

    public float speed;
    public float boosttimer;
    public bool boosting = false;

    void Start() {
        speed = 5;
        boosttimer = 0;
        boosting = false;
    }

 
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player"){
            this.gameObject.SetActive(false);{
            speed = 10;
            boosttimer -= 1;
            if (boosttimer == 0) {
                timer = 100;
                OnTriggerEnter = false;
                }
            else boosting = false;
            
            
            }
        }
    
    }

}