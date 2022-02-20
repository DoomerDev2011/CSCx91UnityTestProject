using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    
    private bool isActive = false;

    void Start(){
        pauseMenu.SetActive(isActive);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && isActive){
            Resume();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && !isActive){
            Pause();
        }
    }

    public void ToggleMenu(){
       isActive = !isActive;
       pauseMenu.SetActive(isActive);
       if(isActive){
           Time.timeScale = 0f;
        } 
       else{
           Time.timeScale = 1f;
        } 
    }

    void Resume(){
        isActive = false;
        pauseMenu.SetActive(isActive);
        Time.timeScale = 1f;
    }

    void Pause(){
        isActive = true;
        pauseMenu.SetActive(isActive);
        Time.timeScale = 0f;
    }
}
