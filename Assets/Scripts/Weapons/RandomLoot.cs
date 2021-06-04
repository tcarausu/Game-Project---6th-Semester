using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLoot : MonoBehaviour
{
    public int[] weaponTable = 
    {
        100, //Sword
        75, //Dagger
        50, //Bow
        25  //BattleAxe
    };

    public int[] Swords =
    {
        100,    //common
        80,     //uncommon
        60,     //rare
        40,     //epic
        20,     //legendary
    };

    public List<GameObject> weapons;
    public int total;
    public int randomNum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Randomize()
    {
        foreach(var item in weaponTable)
        {
            total += item;
        }

        randomNum = Random.Range(0, total);


        //for(int i = 0; i < weaponTable.Length; i++)
        //{
          //  if(randomNum <= weaponTable[i])
            //{
              //  weapons[i].SetActive(true);
                //return;
            //}
            //else
            //{
             //   randomNum -= weaponTable[i];
            //}
        //}
    
        foreach(var weight in weaponTable)
        {
            if (randomNum <= weight)
            {
                Debug.Log("Award" + weight);
                return;
            
            }
            else
            {
                randomNum -= weight;
            }
        }
    }


}
