using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UtilityClass;

public class PlayerMelee : MonoBehaviour, PlayerAttack
{

    private Transform aimTransform, weaponTransform;
    public Animator aimAnimator;

    private bool isAttacking = false;
    public bool isFacingLeft { get; set; } = false;

    public bool getIsAttacking()
    {
        return isAttacking;
    }

    [SerializeField] // use 0 position for normal attacks and 1 for heavy 
    private AudioClip[] swordAttackSounds, axeAttackSounds, daggerAttackSounds;

    private GameObject thePlayer;
    private PlayerBehaviourScript playerScript;
    private AudioSource playerAudioSource;
    private StaminaScript staminaScriptMelee;
    private float attackDamage;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        weaponTransform = aimTransform.Find("Weapon");
        aimAnimator = weaponTransform.GetComponent<Animator>();

        thePlayer = GameObject.Find("Player");

        playerScript = thePlayer.GetComponent<PlayerBehaviourScript>();
        playerAudioSource = thePlayer.GetComponent<AudioSource>();

        staminaScriptMelee = playerScript.stamScript;

    }

    private void Update()
    {

        handleAiming();
        playerAttack();
    }

    private void handleAiming()
    {
        var mouseDirection = UtilityClass.getMouseDirection(transform);

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle);


        if (angle >= 90 && angle <= 180)
        {
            isFacingLeft = true;
        }
        else
        {
            isFacingLeft = false;
        }

    }


    public void playerAttack()
    {
        SpriteRenderer meleeWeaponRenderer = weaponTransform.GetComponent<SpriteRenderer>();

        SwapWeaponSprite currentWeapon = gameObject.GetComponentInChildren<SwapWeaponSprite>();

        if (UtilityClass.ContainsWithLowercase(meleeWeaponRenderer.sprite.name, UtilityClass.swordType))
        {
            swordAttackTriggerAndAnimation(currentWeapon);
        }
        else if (UtilityClass.ContainsWithLowercase(meleeWeaponRenderer.sprite.name, UtilityClass.axeType))
        {
            axeAttackTriggerAndAnimation(currentWeapon);
        }

        else if (UtilityClass.ContainsWithLowercase(meleeWeaponRenderer.sprite.name, UtilityClass.daggerType))
        {
            daggerAttackTriggerAndAnimation(currentWeapon);

        }
    }

    private void swordAttackTriggerAndAnimation(SwapWeaponSprite currentWeapon)
    {
        if (Input.GetMouseButtonDown(0))
        {

            attackDamage = currentWeapon.getCurrentUsingWeapon().fastAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Sword_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses sword normal attack
                StartCoroutine(attackWithMeleeWeapon(swordAttackSounds[0]));

            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            attackDamage = currentWeapon.getCurrentUsingWeapon().heavyAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Sword_Heavy_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses sword heavy attack
                StartCoroutine(attackWithMeleeWeapon(swordAttackSounds[1]));
            }
        }
    }

    private void axeAttackTriggerAndAnimation(SwapWeaponSprite currentWeapon)
    {
        if (Input.GetMouseButtonDown(0))
        {

            attackDamage = currentWeapon.getCurrentUsingWeapon().fastAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Sword_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses axe normal attack
                StartCoroutine(attackWithMeleeWeapon(axeAttackSounds[0]));

            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            attackDamage = currentWeapon.getCurrentUsingWeapon().heavyAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Sword_Heavy_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses axe heavy attack
                StartCoroutine(attackWithMeleeWeapon(axeAttackSounds[1]));
            }
        }
    }

    private void daggerAttackTriggerAndAnimation(SwapWeaponSprite currentWeapon)
    {
        if (Input.GetMouseButtonDown(0))
        {

            attackDamage = currentWeapon.getCurrentUsingWeapon().fastAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Dagger_Quick_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses dagger normal attack
                StartCoroutine(attackWithMeleeWeapon(daggerAttackSounds[0]));

            }
        }

        else if (Input.GetMouseButtonDown(1))
        {
            attackDamage = currentWeapon.getCurrentUsingWeapon().heavyAttackDamage;

            if (staminaScriptMelee.slider.value >= attackDamage)
            {
                aimAnimator.SetTrigger("Dagger_Heavy_Attack");

                UtilityClass.useStamina(staminaScriptMelee, attackDamage);

                //uses dagger heavy attack
                StartCoroutine(attackWithMeleeWeapon(daggerAttackSounds[1]));
            }
        }
    }

    IEnumerator attackWithMeleeWeapon(AudioClip attackSound)
    {
        isAttacking = true;
        playWeaponAttackSound(playerAudioSource, attackSound);

        yield return new WaitForSeconds(.5f);
        isAttacking = false;
    }

    public void playWeaponAttackSound(AudioSource playerAudioSource, AudioClip attackSound)
    {
        playerAudioSource.PlayOneShot(attackSound);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        TargetScript target = collider.GetComponent<TargetScript>();

        SwapWeaponSprite currentWeapon = gameObject.GetComponentInChildren<SwapWeaponSprite>();

        if ((target != null) & isAttacking == true)
        {
            target.damage(attackDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Enemy targetEnemy = collision.gameObject.GetComponent<Enemy>();

        if ((targetEnemy != null) & isAttacking == true)
        {
            targetEnemy.TakeDamage((int)attackDamage);
        }
    }
}
