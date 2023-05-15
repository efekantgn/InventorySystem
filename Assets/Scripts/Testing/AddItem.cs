using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public ItemSO[] Items;
    public InventorySlot Pocket;
    public InventorySlot Backpack;
    public bool AddToBackpack=true;

    public void AddRandomItem()
    {
        if (AddToBackpack)
        {
            Backpack.AddItem(Items[Random.Range(0, Items.Length)]);
        }
        else
        {
            Pocket.AddItem(Items[Random.Range(0, Items.Length)]);
        }
    }
    
}
