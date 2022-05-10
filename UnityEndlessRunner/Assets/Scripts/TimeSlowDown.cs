using System.Collections;

using System.Collections.Generic;
using UnityEngine;
/*Here is the script to have the Time Slow Down ability*/
public class TimeSlowDown : MonoBehaviour {
    /*add the variable 'gm' in this script*/
    private GameManager gm;
        /*defind and set GameManager to the GameObject 'GameManager' when the program start*/
    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    /*When the 'player' hit this Object'*/
     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
            gm.slowing = true;/*the variable'active' in gm will set to true*/
            gm.slowtimer = 10;
            Time.timeScale = 0.5f;/*Set the game timespeed to 0.5 */
            Destroy(this.gameObject);/*Delete the this gameObjrct*/
        }
    }

    
}