using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public GameObject mainMenu;
    public Button playButton, settingsButton, quitButton;

    private bool isActive = false;

    void Start()
    {
        mainMenu.SetActive(isActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
