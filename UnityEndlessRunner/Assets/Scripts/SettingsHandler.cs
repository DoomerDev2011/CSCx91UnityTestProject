using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject settingsMenu;
    public Camera playerCam;
    public Canvas uiCanvas;
    public Slider fovSlider, uiScaleSlider, soundSlider;
    public Button returnButton;
    public Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;

    private bool isActive = false;

    void Start()
    {
        settingsMenu.SetActive(isActive);
        initPlayerSettings();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActive){
            Return();
        }
    }

    public void openSettings(){
       isActive = true;
       settingsMenu.SetActive(isActive);
    }

    public void Return(){
       isActive = false;
       settingsMenu.SetActive(isActive); 
       PlayerPrefs.Save();
    }

    public void fovScale(){
        playerCam.fieldOfView = 60 * fovSlider.value;
        PlayerPrefs.SetFloat("fovScale", fovSlider.value);
    }

    public void uiScale(){
        uiCanvas.scaleFactor = uiScaleSlider.value;
        PlayerPrefs.SetFloat("uiScale", uiScaleSlider.value);
    }

    public void soundScale(){
        AudioListener.volume = soundSlider.value;
        PlayerPrefs.SetFloat("soundScale", soundSlider.value);
    }

    public void initPlayerSettings(){
        fovSlider.value = PlayerPrefs.GetFloat("fovScale");
        fovScale();
        uiScaleSlider.value = PlayerPrefs.GetFloat("uiScale");
        uiScale();
        soundSlider.value = PlayerPrefs.GetFloat("soundScale");
        soundScale();
    }

}
