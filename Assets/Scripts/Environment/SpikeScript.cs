using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{

    [SerializeField] private int damageAmount;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerBehaviourScript player = collider.GetComponent<PlayerBehaviourScript>();

        if (player != null)
        {
            Vector3 knockbackDir = (player.getPosition() - transform.position).normalized;

            //player.damageKnockBack(knockbackDir, 5f, damageAmount);
            HeartsHealthVisual.heartsHealthSystemStatic.damage(damageAmount);

        }
    }

}
