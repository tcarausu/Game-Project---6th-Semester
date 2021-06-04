using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=Nke5JKPiQTw 16m+ for physics
//https://www.youtube.com/watch?v=AXkaqW3E9OI 13m+ for enemyMelee

public class TargetScript : MonoBehaviour
{

    private static float health = 100f;
    private static List<TargetScript> enemyList;

    private void Awake()
    {
        if (enemyList == null) enemyList = new List<TargetScript>();


        TargetScript enemy = transform.GetComponent<TargetScript>();
        enemyList.Add(enemy);
    }

    void Update()
    {
        // keep it here or in the damage method?
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("dead" + health);
        }

    }

    internal void damage(float attackDamage)
    {

        if (health > 0)
        {
            health -= attackDamage;
            Debug.Log("Target damaged" + health);
        }

    }

    public static TargetScript getClosestEnemy(Vector3 position, float range)
    {

        if (enemyList == null) return null;

        TargetScript closestEnemy = null;

        for (int i = 0; i < enemyList.Count; i++)
        {
            TargetScript testEnemy = enemyList[i];

            float positionToTestEnemy = Vector3.Distance(position, testEnemy.getPosition());

            if (positionToTestEnemy > range)
            {
                continue;
            }

            if (closestEnemy == null)
            {
                closestEnemy = testEnemy;
            }
            else
            {
                if (positionToTestEnemy < Vector3.Distance(position, closestEnemy.getPosition()))
                {
                    closestEnemy = testEnemy;
                }
            }
        }


        return closestEnemy;
    }



    private Vector3 getPosition()
    {
        return transform.position;
    }
}
