using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject settingsMenu;
    public Camera playerCam;
    public Canvas uiCanvas;
    public Slider fovSlider, soundSlider;
    public Button returnButton;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

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

    public void openSettings(){
       isActive = true;
       settingsMenu.SetActive(isActive);
    }

    public void Return(){
       Debug.Log("aaaaaaaaaa");
       isActive = false;
       settingsMenu.SetActive(isActive); 
       PlayerPrefs.Save();
    }

    public void fovScale(){
        playerCam.fieldOfView = 60 * fovSlider.value;
        PlayerPrefs.SetFloat("fovScale", fovSlider.value);
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
        fovSlider.value = PlayerPrefs.GetFloat("fovScale");
        fovScale();
        soundSlider.value = PlayerPrefs.GetFloat("soundScale");
        soundScale();
        resolutionDropdown.value = PlayerPrefs.GetInt("resDropdownValue");
        isFullscreen = PlayerPrefs.GetInt("isFullscreen")==1 ? true : false;
        fullscreenToggle.SetIsOnWithoutNotify(isFullscreen);
        resolutionChanger();
    }

}
