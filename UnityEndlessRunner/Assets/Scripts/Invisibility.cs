using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisibility : MonoBehaviour {

    private SpriteRenderer character;
    private Color col;
    private float activationtime;
    private bool invisible;


    void Start()
    {
        character = GetComponent<SpriteRenderer>();
        activationtime = 0;
        invisible = false;
        col = character.color;
    }

    void Pickup()
    {
        activationtime += Time.deltatime;
        if (invisible && activationtime >= 10) {
            invisible = false;
            col.a = 1;
            character.color = col;
        }
       
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "invisible"){

            invisible = true;
            activationtime = 0;
            col.a = .2f;
            character.color = col;
            other.gameObject.SetActive(false);

        }
    }

}