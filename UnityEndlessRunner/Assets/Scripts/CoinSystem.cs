using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour

{
    public int score = 0;
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
    }
}
