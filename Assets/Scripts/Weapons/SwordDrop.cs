using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDrop : MonoBehaviour
{
    public int[] Swords =
    {
        100,    //common
        80,     //uncommon
        60,     //rare
        40,     //epic
        20,     //legendary
    };

    public GameObject my_chest;
    RandomLoot my_chest_script;

    private void Start()
    {
        my_chest_script = my_chest.GetComponentInParent<RandomLoot>();
    }

    public void Drop()
    {
        my_chest_script.Randomize();

    }

}
