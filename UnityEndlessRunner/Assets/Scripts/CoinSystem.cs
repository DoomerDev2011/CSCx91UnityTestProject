using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSystem : MonoBehaviour

{
    public int score = 0; // Initial score is set to 0
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
            score += 2; // Increase the score
            timer -= 1; // Decrease the time
            if (timer == 0) { // If the timer reaches 0, reset the timer and set the Multiplier to false
                timer = 100;
                multiplierActive = false;
            }
        }else {score+=1;} // Otherwise keep increasing the score
    }
}
