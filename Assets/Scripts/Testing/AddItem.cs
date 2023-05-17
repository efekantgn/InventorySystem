using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public ItemSO[] Items;
    public InventorySlot Pocket;
    public InventorySlot Backpack;


    public bool AddToBackpack=true;

    private Inventory _inventory;

    public Inventory Inventory { get => _inventory; set => _inventory = value; }

    private void Start()
    {
        Inventory=FindObjectOfType<Inventory>();
    }

    public void AddRandomItem()
    {

        int random = Random.Range(0, Items.Length);
        ItemData temp = DataConverter.ConvertItemSOToItemData(Items[random]);
        Inventory.InstantiateUIElement(temp,MainPanel.Instance.BackpackPanel.transform);
        //if (AddToBackpack)
        //{
            

        //    Backpack.AddItem(Items[Random.Range(0, Items.Length)]);
        //}
        //else
        //{
        //    Pocket.AddItem(Items[Random.Range(0, Items.Length)]);
        //}
    }

    
    
}
