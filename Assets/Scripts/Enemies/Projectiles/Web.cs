using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : Projectile
{
    public Animator animator;
    void Start() 
    {
        velocity = 0.025f;
        direction = (target.transform.position - this.transform.position).normalized;
        damage = 1;
    }

    void Update()
    {
        Move(target);
    }

    private void OnCollisionEnter2D(Collision2D hit) {
        if(hit.gameObject.name == "Player") {
            HeartsHealthVisual.heartsHealthSystemStatic.damage(damage);
        }
        //Debug.Log("Hit " + hit.gameObject.name);
        Hit(hit.gameObject);
    }
}