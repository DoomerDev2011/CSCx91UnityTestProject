using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instence;
    public static int Coins;
    public static float timer;

    void Awake(){
        Instence = this;
    }
}
public enum GameState{
    CoinSystem,
    TimeSlowDown,
}
