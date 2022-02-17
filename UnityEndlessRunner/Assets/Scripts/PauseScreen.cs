using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool PauseScreenStatus;



    public void PauseScreenToggle(){
        //if onCLick(){
           // pauseMenu.SetActive(true);
        //}
        //if the PauseScreenStatus is false
            // turn on PauseScreen object
            // set the timeScale to be 0
        // else
            // turn off PauseScreen object
            // set the timeScale to be 1 

    }

    //public void OnClick(){
      //  PauseScreenStatus = !PauseScreenStatus;
    //}

    void Start(){
        pauseMenu.SetActive(false);
    }
    

}
