using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour
{   
    public static GameManager GameManager;
    void OnCollisionEnter(Collision other){
        if (other.gameObject.tag == "Player"){
            Debug.Log("add coin");
            GameManager.Coins += 1;
            Destroy(gameObject);
            print("There are "+ GameManager.Coins+" Coins");
        }
    }


 /*   public int score = 0;
    public bool multiplierActive = false;
    public int timer = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (multiplierActive) {
            score += 2;
            timer -= 1;
            if (timer == 0) {
                timer = 100;
                multiplierActive = false;
            }
        }else {score+=1;}
    }*/
}
