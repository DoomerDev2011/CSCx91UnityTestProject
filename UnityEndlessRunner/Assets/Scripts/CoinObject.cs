using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinObject: MonoBehaviour {
    
    [SerializeField]
    private GameManager gm; // Reference to the GameManager

    void Start(){
        gm = GameObject.Find("GameManager").GetComponent<GameManager>(); // The Start Script is in the GameManager
    }

     void OnCollisionEnter(Collision other){
         if (other.gameObject.tag == "Player"){
             gm.Coins += 1; // Increase coins by 1
             Debug.Log ("Coins in Game manager:" + gm.Coins.ToString());
             Destroy(this.gameObject); // Destroys the power-up object
         }
     }
}
