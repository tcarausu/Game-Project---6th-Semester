using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Sword,
        BattleAxe,
        Bow,
        Daggers,
        Potion,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:

            case ItemType.Sword: return ItemAssets.Instance.swordWeapon.sprite;
            case ItemType.Daggers: return ItemAssets.Instance.daggerWeapon.sprite;
            case ItemType.BattleAxe: return ItemAssets.Instance.battleAxeWeapon.sprite;
            case ItemType.Bow: return ItemAssets.Instance.bowWeapon.sprite;
            case ItemType.Potion: return ItemAssets.Instance.potionItem.sprite;
        }
    }

    public WeaponItem getWeaponItem()
    {
        switch (itemType)
        {
            default:

            case ItemType.Sword: return ItemAssets.Instance.swordWeapon;
            case ItemType.Daggers: return ItemAssets.Instance.daggerWeapon;
            case ItemType.BattleAxe: return ItemAssets.Instance.battleAxeWeapon;
            case ItemType.Bow: return ItemAssets.Instance.bowWeapon;

        }
    }
    public HealingItem getHealingItem()
    {
        switch (itemType)
        {
            default:

            case ItemType.Potion: return ItemAssets.Instance.potionItem;

        }
    }

}