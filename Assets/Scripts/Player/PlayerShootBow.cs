using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UtilityClass;

public class PlayerShootBow : MonoBehaviour, PlayerAttack
{

    public event EventHandler<OnShootEventArgs> OnShoot;
    private bool isShooting = false;
    public bool isFacingLeft { get; set; } = false;

    public bool getIsShooting()
    {
        return isShooting;
    }


    public bool isAttackingWithBow()
    {
        return isShooting;
    }
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 bowEndPointPosition;
        public Vector3 shootPosition;

    }

    private Transform aimTransform, bowEndTransform, weaponTransform;
    public Animator aimAnimator;

    private GameObject thePlayer;
    private AudioSource playerAudioSource;

    private PlayerBehaviourScript playerScript;
    private StaminaScript staminaScriptRanged;
    private double attackDamage;

    [SerializeField]
    private AudioClip shootBow, shootFireBow;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        weaponTransform = aimTransform.Find("Weapon");
        bowEndTransform = weaponTransform.Find("Bow_endpoint");
        aimAnimator = weaponTransform.GetComponent<Animator>();

        thePlayer = GameObject.Find("Player");

        playerScript = thePlayer.GetComponent<PlayerBehaviourScript>();
        playerAudioSource = thePlayer.GetComponent<AudioSource>();
        staminaScriptRanged = playerScript.stamScript;
    }

    private void Start()
    {
        attackDamage = (double)UsedStaminaForAttack.arrowAttack;
    }

    void Update()
    {
        handleAiming();
        playerAttack();
    }

    private void handleAiming()
    {
        var mouseDirection = UtilityClass.getMouseDirection(transform);

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;


        if (angle >= 90 && angle <= 180)
        {
            isFacingLeft = true;
        }
        else
        {
            isFacingLeft = false;
        }


        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public void playerAttack()
    {
        var mouseDirection = UtilityClass.getMouseDirection(transform);

        if ((staminaScriptRanged.slider.value >= attackDamage) && Input.GetMouseButtonDown(0))
        {
            StartCoroutine(attackWithBow(mouseDirection));

            UtilityClass.useStamina(staminaScriptRanged, attackDamage);
        }
    }

    public void playBowSound(AudioSource playerAudioSource)
    {
        playerAudioSource.PlayOneShot(shootBow);
    }

    IEnumerator attackWithBow(Vector2 mouseDirection)
    {
        isShooting = true;
        aimAnimator.SetTrigger("Shoot_Arrow");

        playBowSound(playerAudioSource);

        OnShoot?.Invoke(this, new OnShootEventArgs
        {
            bowEndPointPosition = bowEndTransform.position,
            shootPosition = mouseDirection,
        });

        yield return new WaitForSeconds(.5f);
        isShooting = false;
    }
}

