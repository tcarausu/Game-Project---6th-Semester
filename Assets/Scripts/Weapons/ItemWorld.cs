using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemWorld : MonoBehaviour
{

    private int UIWeaponPositon = 1;

    private Image weapon1, weapon2;

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item, string Tag, bool isWeapon)
    {
        Transform transform = Instantiate(ItemAssets.Instance.swItemWorld, position, Quaternion.identity);
        transform.gameObject.tag = Tag;

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.setIsItem(isWeapon);
        itemWorld.SetItem(item);

        return itemWorld;
    }

    private Item item;
    private WeaponItem weaponItem;
    private HealingItem healingItem;
    private SpriteRenderer spriteRenderer;
    private bool isItemWeapon;

    //Needs to be AWAKE, can't be Start
    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void setIsItem(bool isWeapon)
    {
        this.isItemWeapon = isWeapon;
    }

    public void SetItem(Item item)
    {
        this.item = item;

        if (isItemWeapon)
        {
            this.weaponItem = item.getWeaponItem();
        }
        else
        {
            this.healingItem = item.getHealingItem();
        }
        spriteRenderer.sprite = item.GetSprite();

    }

    public Item GetItem()
    {
        return item;
    }

    public bool isWeapon()
    {
        return isItemWeapon;
    }
    public WeaponItem GetWeaponItem()
    {
        return weaponItem;

    }
    public HealingItem GetHealingItem()
    {
        return healingItem;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }


    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        setUIWeapPos1(weapon2);
    //        setUIWeapPos2(weapon1);
    //    }
    //}



    //public int getUIWeaponPositon()
    //{
    //    return UIWeaponPositon;
    //}
    //public void setUIWeaponPositon(int weaponPos)
    //{
    //    this.UIWeaponPositon = weaponPos;
    //}

    //public Image getWeapon1()
    //{
    //    return weapon1;
    //}
    //public void setUIWeapPos1(Image weapon2Use)
    //{
    //    this.weapon1 = weapon2Use;
    //}

    //public Image getWeapon2()
    //{
    //    return weapon2;
    //}
    //public void setUIWeapPos2(Image weapon2Use)
    //{
    //    this.weapon2 = weapon2Use;
    //}
}
