using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConverter : MonoBehaviour
{
    public static ItemData ConvertItemSOToItemData(ItemSO itemSO)
    {
        ItemData itemData = new ItemData();
        itemData.ItemID=itemSO.ItemID;
        itemData.ItemName=itemSO.ItemName;
        itemData.ItemDescription=itemSO.ItemDescription;
        itemData.ItemStackable=itemSO.ItemStackable;
        itemData.ItemCount=itemSO.ItemCount;
        itemData.ItemIcon=itemSO.ItemIcon;

        return itemData;
    }
}
