using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Toggle muteToggle;
    
    private bool isActive = false;
    private bool isMuted = false;

    void Start(){
        pauseMenu.SetActive(isActive);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && isActive && !settingsMenu.activeSelf){
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

    public void toggleMute(){
        isMuted = !isMuted;
        if(isMuted){
            AudioListener.volume = 0;
        }
        else{
            AudioListener.volume = PlayerPrefs.GetFloat("soundScale");
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

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void quitGame(){
        Application.Quit();
    }


}
