using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public Animator animator;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject gameOverMenu;
    public Toggle muteToggle;
    
    private bool gameOver;
    private bool gameOverMenuActive = false;
    private bool isActive = false;
    private bool isMuted = false;

    void Start(){
        pauseMenu.SetActive(isActive);
        gameOverMenu.SetActive(gameOverMenuActive);
    }

    void Update(){
        gameOver = animator.GetBool("gameOver");

        if(!gameOver){
            if(Input.GetKeyDown(KeyCode.Escape) && isActive && !settingsMenu.activeSelf){
                Resume();
            }

            else if(Input.GetKeyDown(KeyCode.Escape) && !isActive){
                Pause();
            }
        }
        else{
            Invoke("gameOverFunc", 3f);
        }
        
    }

    public void ToggleMenu(){
        if(!gameOver){
            isActive = !isActive;
            pauseMenu.SetActive(isActive);
            if(isActive){
                Time.timeScale = 0f;
            } 
            else{
                Time.timeScale = 1f;
            } 
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

    void gameOverFunc(){
        gameOverMenuActive = true;
        gameOverMenu.SetActive(gameOverMenuActive);
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

    public void Quit(){
        Application.Quit();
    }

}
