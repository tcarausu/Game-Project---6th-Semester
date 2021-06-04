using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlantScript : MonoBehaviour
{

    [SerializeField] private int healAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerBehaviourScript player = collider.GetComponent<PlayerBehaviourScript>();

        if (player != null)
        {

            player.healPlayer(healAmount);
            Destroy(gameObject);
        }
    }

}
