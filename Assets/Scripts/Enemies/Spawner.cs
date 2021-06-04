using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int difficulty = 0, roomVal = 0;
    public GameObject[] spawners;
    public int SpiderVal = 2, ZombieVal = 1, SlimeVal = 1;
    public GameObject Spider, Zombie, Slime;

    private void OnEnable() {
        try {
            spawners = GameObject.FindGameObjectsWithTag("Spawner");
            Debug.Log("Test");
            foreach(GameObject spawn in spawners) {
                if(roomVal < difficulty) {
                    switch (UnityEngine.Random.Range(0, 3)) {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    
                    //Instantiate();
                    roomVal++;
                }
                else {
                    break;
                }
            }
            difficulty++; 
            this.enabled = false;
        }
        catch (Exception e){
            Debug.Log(e);
        }
    }
}