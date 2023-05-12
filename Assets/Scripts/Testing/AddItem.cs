using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public ItemSO[] Items;
    public Inventory Inventory;

    public void AddRandomItem()
    {
        Inventory.AddItem(Items[Random.Range(0,Items.Length)]);
    }
}
