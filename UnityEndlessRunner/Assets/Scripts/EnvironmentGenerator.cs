using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public GameObject environment;              // This is our parent GameObject, which the scripts are attached to and the instantiated prefabs will be spawned under. 
    public GameObject[] availableBlocks;        // This is the array used to store the 'blocks' which we can instantiate.

    private List<GameObject> instantiatedBlocks = new List<GameObject>();  // This is the list used to store the 'blocks' which have been instantiated.
    
    void Start()    // Simple for loop used to spawn blocks 1, 2, and 3 at the start of the game.
    {
        for(int i = 0; i<availableBlocks.Length; i++){
            GameObject temp = Instantiate(availableBlocks[i], new Vector3(0, 0, i * 27.5f), Quaternion.identity);
            temp.transform.SetParent(environment.transform, false);  
            instantiatedBlocks.Add(temp); 
        }
    }                        

    void Update()
    {
                                                       
        for(int i = 0; i<instantiatedBlocks.Count; i++){
            instantiatedBlocks[i].transform.Translate(0, 0, (Time.timeScale / 20) * -1, Camera.main.transform);
                                                            // "(Time.timeScale / 20) * -1", This moves each instantiated block 1 unit backwards every 20th of an unpaused second. 
            if(instantiatedBlocks[i].transform.position.z <= -27.5f){ 
                Destroy(instantiatedBlocks[i]); // This destroys the GameObject and removes it from the array if it passes behind the camera.
                instantiatedBlocks.RemoveAt(i);
            }
        }
        if(instantiatedBlocks.Count < 3){           // Instantiates a new block every time one is removed from the array.
            GameObject temp = Instantiate(availableBlocks[UnityEngine.Random.Range(0,3)], new Vector3(0, 0, instantiatedBlocks[1].transform.position.z + 27.5f), Quaternion.identity);
            temp.transform.SetParent(environment.transform, false);                                                                         
            instantiatedBlocks.Add(temp);
        }
    }


}
