using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public GameObject environment;              // This is our parent GameObject, which the scripts are attached to and the instantiated prefabs will be spawned under. 
    public GameObject[] availableBlocks;        // This is the array used to store the 'blocks' which we can instantiate.

    private List<GameObject> instantiatedBlocks = new List<GameObject>();  // This is the list used to store the 'blocks' which have been instantiated.

    [SerializeField] int instantiatedLast = 30; // temporarily assigned to 30, because this value gets changed after the first time the randomNumber() function is called
    
    void Start()    // Simple for loop used to spawn blocks 1, 2, and 3 at the start of the game.
    {
        for(int i = 0; i<availableBlocks.Length - 3; i++){
            GameObject temp = Instantiate(availableBlocks[randomNumber()], new Vector3(0, 0, i * 27.5f), Quaternion.identity);
            temp.transform.SetParent(environment.transform, false);  
            instantiatedBlocks.Add(temp); 
        }
    }                        

    void Update()
    {                                             
        for(int i = 0; i<instantiatedBlocks.Count; i++){                  
            instantiatedBlocks[i].transform.Translate(0, 0, (Time.deltaTime * -10), Camera.main.transform);
                                                            // "(Time.deltaTime * -5), Camera.main.transform", moves everything backwards in relation to the camera.
            if(instantiatedBlocks[i].transform.position.z <= -27.5f){ 
                Destroy(instantiatedBlocks[i]); // This destroys the GameObject and removes it from the array if it passes behind the camera.
                instantiatedBlocks.RemoveAt(i);
            }
        }

        if(instantiatedBlocks.Count < 5){           // Instantiates a new block every time one is removed from the array.
            GameObject temp = Instantiate(availableBlocks[randomNumber()], new Vector3(0, 0, instantiatedBlocks[3].transform.position.z + 27.5f), Quaternion.identity);
            temp.transform.SetParent(environment.transform, false);                                                                         
            instantiatedBlocks.Add(temp);
        }
    }

    private int randomNumber(){
        int temp = UnityEngine.Random.Range(0,8);
        if(instantiatedLast == 0 && temp == 0){
            temp++;
            instantiatedLast = temp;
            return instantiatedLast;
        }
        else if(instantiatedLast == availableBlocks.Length - 1 && temp == availableBlocks.Length - 1){
            temp--;
            instantiatedLast = temp;
            return instantiatedLast;
        }
        else if(temp == instantiatedLast){
            int temp2 = UnityEngine.Random.Range(0,2);
            if(temp2 == 1){
                temp++;
            }
            else{
                temp--;
            }
            instantiatedLast = temp;
            return instantiatedLast;
        }
        else{
            instantiatedLast = temp;
            return instantiatedLast;
        }
    }

}
