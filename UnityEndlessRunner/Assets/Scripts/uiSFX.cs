using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiSFX : MonoBehaviour
{
    public AudioSource buttonSFX;

    public void buttonPress(){
        buttonSFX.Play();
    }
}
