using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapWeaponSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private WeaponItem startingWeapon;
    [SerializeField] private Image mainWeaponUI, secondaryWeaponUI;

    private WeaponItem usingWeapon, oldWeapon;
    private bool gotTwoWeapons = false;

    [SerializeField] private Animator weaponAnimator;

    private GameObject player;
    private float degreeToRotate = 45f;


    private void Awake()
    {
        player = GameObject.Find("Player");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        weaponAnimator = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        usingWeapon = startingWeapon;
        oldWeapon = startingWeapon;
        spriteRenderer.sprite = usingWeapon.sprite;
        mainWeaponUI.sprite = usingWeapon.sprite;
    }


    void Update()
    {

        if (!PauseMenu.gameisPaused)
        {
            checkWeaponType();

            //if (Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.E))
            //{
            //    swapWeapon();
            //}

            if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                swapWeapon();
            }


            //rotate only once then the animator is "stuck"
            //    if (Input.GetKeyDown(KeyCode.L))
            //    {
            //        weaponAnimator.SetTrigger("swapHandToRight");
            //    }
            //    else if (Input.GetKeyDown(KeyCode.K))
            //    {
            //        weaponAnimator.SetTrigger("swapHandToLeft");
            //    }
        }

    }

    public void swapWeapon()
    {
        if (secondaryWeaponUI.sprite != null)
        {
            Sprite tempImage = mainWeaponUI.sprite;
            mainWeaponUI.sprite = secondaryWeaponUI.sprite;
            secondaryWeaponUI.sprite = tempImage;

            gotTwoWeapons = true;
            setCurrentUsingWeapon(oldWeapon, false);
        }
        else
        {
            Debug.Log("no weapon in offhand");
        }

    }

    private void checkWeaponType()
    {
        string spriteName = spriteRenderer.sprite.name;

        if (UtilityClass.ContainsWithLowercase(spriteName, UtilityClass.bowType))
        {
            player.GetComponent<PlayerMelee>().enabled = false;
            player.GetComponent<PlayerShootBow>().enabled = true;
        }
        else
        {
            player.GetComponent<PlayerMelee>().enabled = true;
            player.GetComponent<PlayerShootBow>().enabled = false;
        }
    }

    private void rebuildRenderer(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;

        Destroy(GetComponent<PolygonCollider2D>());

        gameObject.AddComponent<PolygonCollider2D>();
    }


    public bool isSecondSlotFree()
    {
        if (secondaryWeaponUI.sprite != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public WeaponItem getCurrentUsingWeapon()
    {
        return usingWeapon;
    }

    public void setCurrentUsingWeapon(WeaponItem weaponItem, bool pickedNewWeapon)
    {

        if (pickedNewWeapon)
        {
            secondaryWeaponUI.GetComponent<Image>().sprite = usingWeapon.sprite;
            mainWeaponUI.GetComponent<Image>().sprite = weaponItem.sprite;

            this.oldWeapon = usingWeapon;
            this.usingWeapon = weaponItem;
            rebuildRenderer(usingWeapon.sprite);
        }

        else
        {
            WeaponItem tempItem = usingWeapon;

            this.usingWeapon = oldWeapon;
            this.oldWeapon = tempItem;
            rebuildRenderer(usingWeapon.sprite);
        }

    }

    private void FixedUpdate()
    {
        PolygonCollider2D itemCollider = gameObject.GetComponent<PolygonCollider2D>();

        itemCollider.isTrigger = true;
    }


}
