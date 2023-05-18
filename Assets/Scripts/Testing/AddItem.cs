using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddItem : MonoBehaviour
{
    public ItemSO[] Items;
    public InventorySlot Pocket;
    public InventorySlot Backpack;


    public bool AddToBackpack=true;

    

    public void AddRandomItem()
    {
        int random = 5/*Random.Range(0, Items.Length)*/;
        if (Items[random].GetType() == typeof(BodySO))
        {
            BodyData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<BodySO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else if (Items[random].GetType() == typeof(HeadSO))
        {
            HeadData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<HeadSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else  if (Items[random].GetType() == typeof(FootSO))
        {
            FootData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<FootSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else if (Items[random].GetType() == typeof(ConsumableSO))
        {
            ConsumableData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<ConsumableSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else if (Items[random].GetType() == typeof(OneHandedSO))
        {
            OneHandedData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<OneHandedSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else if (Items[random].GetType() == typeof(TwoHandedSO))
        {
            TwoHandedData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<TwoHandedSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        else if (Items[random].GetType() == typeof(OffHandSO))
        {
            OffHandData temp = DataConverter.ConvertItemSOToItemData(Items[random].ConvertTo<OffHandSO>());
            Inventory.Instance.AddItem(temp, MainPanel.Instance.BackpackPanel.transform);
        }
        
        
       
    }

    
    
}
