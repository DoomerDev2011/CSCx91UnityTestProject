using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
    public Button playButton, settingsButton, quitButton;
    public GameObject settingsMenu;
    public Canvas uiCanvas;
    public Slider soundSlider;
    public Button returnButton;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    public AudioSource buttonPressSFX;
    
    private bool isActive = false;
    private bool isFullscreen = true;

    void Awake(){
        settingsMenu.SetActive(isActive);
        initPlayerSettings();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && isActive){
            Return();
        }
    }

    public void Quit(){
        Application.Quit();
    }

    public void openSettings(){
       isActive = true;
       settingsMenu.SetActive(isActive);
    }

    public void Play(){
        SceneManager.LoadScene("Environment Gen");
    }

    public void Return(){
       isActive = false;
       settingsMenu.SetActive(isActive); 
       PlayerPrefs.Save();
    }

    public void soundScale(){
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("soundScale", soundSlider.value);
    }

    public void toggleFullscreen(){
        isFullscreen = !isFullscreen;
        PlayerPrefs.SetInt("isFullscreen", isFullscreen ? 1 : 0);
        resolutionChanger();
    }

    public void resolutionChanger(){
        switch(resolutionDropdown.value){
            case 0:
                Screen.SetResolution(1920,1080, isFullscreen);
                break;
            case 1:
                Screen.SetResolution(1280,1024, isFullscreen);
                break;
            case 2:
                Screen.SetResolution(800,600, isFullscreen);
                break;
        }
        PlayerPrefs.SetInt("resDropdownValue", resolutionDropdown.value);
    }

    public void initPlayerSettings(){
        soundSlider.value = PlayerPrefs.GetFloat("soundScale");
        soundScale();
        resolutionDropdown.value = PlayerPrefs.GetInt("resDropdownValue");
        isFullscreen = PlayerPrefs.GetInt("isFullscreen")==1 ? true : false;
        fullscreenToggle.SetIsOnWithoutNotify(isFullscreen);
        resolutionChanger();
    }

    public void buttonPress(){
        buttonPressSFX.Play();
    }

}
