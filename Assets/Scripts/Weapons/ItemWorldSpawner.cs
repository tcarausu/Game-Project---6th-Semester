using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorldSpawner : MonoBehaviour
{

    public Item item;

    private void Start()
    {

        ItemWorld.SpawnItemWorld(transform.position, item, tag = "Weapon", checkIsWeaponItemType(item.itemType));
        Destroy(gameObject);
    }

    public bool checkIsWeaponItemType(Item.ItemType itemType)
    {
        if (UtilityClass.ContainsWithLowercase(itemType.ToString(), UtilityClass.bowType))
        {
            return true;
        }

        else if (UtilityClass.ContainsWithLowercase(itemType.ToString(), UtilityClass.swordType))
        {
            return true;
        }

        else if (UtilityClass.ContainsWithLowercase(itemType.ToString(), UtilityClass.daggerType))
        {
            return true;
        }

        else if (UtilityClass.ContainsWithLowercase(itemType.ToString(), UtilityClass.axeType))
        {
            return true;
        }

        else if (UtilityClass.ContainsWithLowercase(itemType.ToString(), UtilityClass.potionType))
        {
            return false;
        }

        return false;
    }
}
