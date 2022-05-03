using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject: MonoBehaviour {
    
    private GameManager gm;

    void Start(){
        gm = gameObject.Find("GameManager").GetComponent<GameManager>();
    }

     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
             gm.Coins += 1;
             Debug.Log ("Coins in Game manager:" + gm.Coins.ToString());
             Destroy(this.gameObject);
         }
     }
}
