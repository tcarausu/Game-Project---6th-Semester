using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_ArrowScript_Physics : MonoBehaviour
{

    private float moveSpeed = 10f;
    private int attackDamage = 5;

    private SwapWeaponSprite currentWeaponScript;


    public void setup(Vector3 shootDir, SwapWeaponSprite currentWeapon)
    {
        currentWeaponScript = currentWeapon;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);

        transform.eulerAngles = new Vector3(0, 0, UtilityClass.getAngleFromVectorFloat(shootDir));


        Destroy(gameObject, 5f);
    }

    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    TargetScript target = collider.GetComponent<TargetScript>();

    //    Debug.Log(currentWeaponScript.getCurrentUsingWeapon());
    //    if (target != null)
    //    {
    //        target.damage(currentWeaponScript.getCurrentUsingWeapon().fastAttackDamage);
    //        Destroy(gameObject);
    //    }
    //}


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Enemy targetEnemy = collision.gameObject.GetComponent<Enemy>();

        if (targetEnemy != null)
        {
            Debug.Log("Hit!");
            targetEnemy.TakeDamage((int)attackDamage);
        }
        Destroy(this.gameObject);
    }



}
