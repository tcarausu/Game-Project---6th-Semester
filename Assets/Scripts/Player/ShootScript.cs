using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

    [SerializeField] private Transform shot_Arrow;

    void Awake()
    {
        GetComponent<PlayerShootBow>().OnShoot += PlayerShootBow_OnShoot;
    }

    private void PlayerShootBow_OnShoot(object sender, PlayerShootBow.OnShootEventArgs eventArg)
    {

        StartCoroutine(shootArrow(eventArg));
    }


    IEnumerator shootArrow(PlayerShootBow.OnShootEventArgs e)
    {
        Transform arrowTransformPhysics = Instantiate(shot_Arrow, e.bowEndPointPosition, Quaternion.identity);

        Vector3 shootDir = (e.shootPosition - e.bowEndPointPosition).normalized;

        SwapWeaponSprite currentWeapon = gameObject.GetComponentInChildren<SwapWeaponSprite>();

        //With Physics
        arrowTransformPhysics.GetComponent<Fire_ArrowScript_Physics>().setup(shootDir, currentWeapon);
        yield return new WaitForSeconds(.5f);
    }
}
