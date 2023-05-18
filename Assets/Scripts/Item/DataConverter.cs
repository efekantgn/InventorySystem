using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class DataConverter : MonoBehaviour
{
    
    public static BodyData ConvertItemSOToItemData(BodySO bodySO)
    {
        BodyData itemData = new BodyData();
        itemData.ItemID = bodySO.ItemID;
        itemData.ItemName = bodySO.ItemName;
        itemData.ItemDescription = bodySO.ItemDescription;
        itemData.ItemStackable = bodySO.ItemStackable;
        itemData.ItemCount = bodySO.ItemCount;
        itemData.ItemIcon = bodySO.ItemIcon;
        itemData.armorResistance=bodySO.ArmorResistance;
        return itemData;
    }

    public static HeadData ConvertItemSOToItemData(HeadSO headSO)
    {
        HeadData itemData = new HeadData();
        itemData.ItemID = headSO.ItemID;
        itemData.ItemName = headSO.ItemName;
        itemData.ItemDescription = headSO.ItemDescription;
        itemData.ItemStackable = headSO.ItemStackable;
        itemData.ItemCount = headSO.ItemCount;
        itemData.ItemIcon = headSO.ItemIcon;
        itemData.armorResistance = headSO.ArmorResistance;
        return itemData;
    }

    public static FootData ConvertItemSOToItemData(FootSO footSO)
    {
        FootData itemData = new FootData();
        itemData.ItemID = footSO.ItemID;
        itemData.ItemName = footSO.ItemName;
        itemData.ItemDescription = footSO.ItemDescription;
        itemData.ItemStackable = footSO.ItemStackable;
        itemData.ItemCount = footSO.ItemCount;
        itemData.ItemIcon = footSO.ItemIcon;
        itemData.armorResistance = footSO.ArmorResistance;
        return itemData;
    }
    public static ConsumableData ConvertItemSOToItemData(ConsumableSO consumableSO)
    {
        ConsumableData itemData = new ConsumableData();
        itemData.ItemID = consumableSO.ItemID;
        itemData.ItemName = consumableSO.ItemName;
        itemData.ItemDescription = consumableSO.ItemDescription;
        itemData.ItemStackable = consumableSO.ItemStackable;
        itemData.ItemCount = consumableSO.ItemCount;
        itemData.ItemIcon = consumableSO.ItemIcon;
        return itemData;
    }
    public static OneHandedData ConvertItemSOToItemData(OneHandedSO oneHandedSO)
    {
        OneHandedData itemData = new OneHandedData();
        itemData.ItemID = oneHandedSO.ItemID;
        itemData.ItemName = oneHandedSO.ItemName;
        itemData.ItemDescription = oneHandedSO.ItemDescription;
        itemData.ItemStackable = oneHandedSO.ItemStackable;
        itemData.ItemCount = oneHandedSO.ItemCount;
        itemData.ItemIcon = oneHandedSO.ItemIcon;
        itemData.Damage = oneHandedSO.Damage;
        return itemData;
    }
    public static TwoHandedData ConvertItemSOToItemData(TwoHandedSO twoHandedSO)
    {
        TwoHandedData itemData = new TwoHandedData();
        itemData.ItemID = twoHandedSO.ItemID;
        itemData.ItemName = twoHandedSO.ItemName;
        itemData.ItemDescription = twoHandedSO.ItemDescription;
        itemData.ItemStackable = twoHandedSO.ItemStackable;
        itemData.ItemCount = twoHandedSO.ItemCount;
        itemData.ItemIcon = twoHandedSO.ItemIcon;
        itemData.Damage = twoHandedSO.Damage;
        return itemData;
    }
    public static OffHandData ConvertItemSOToItemData(OffHandSO offHandSO)
    {
        OffHandData itemData = new OffHandData();
        itemData.ItemID = offHandSO.ItemID;
        itemData.ItemName = offHandSO.ItemName;
        itemData.ItemDescription = offHandSO.ItemDescription;
        itemData.ItemStackable = offHandSO.ItemStackable;
        itemData.ItemCount = offHandSO.ItemCount;
        itemData.ItemIcon = offHandSO.ItemIcon;
        itemData.Damage = offHandSO.Damage;
        return itemData;
    }
}
