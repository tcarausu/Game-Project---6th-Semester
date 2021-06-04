using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();

        AddItem(new Item { itemType = Item.ItemType.Sword, });
        AddItem(new Item { itemType = Item.ItemType.BattleAxe });
        AddItem(new Item { itemType = Item.ItemType.Bow });
        AddItem(new Item { itemType = Item.ItemType.Daggers });
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    public List<Item> GetItemList()
    {
        return itemList;
    }
}
