using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    private static CraftingManager _instance;
    private List<ItemData> _itemDatas=new List<ItemData>();


    public static CraftingManager Instance { get => _instance; set => _instance = value; }
    public List<ItemData> ItemDatas { get => _itemDatas; set => _itemDatas = value; }


    private void Awake()
    {
        if (Instance == null || Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        
        foreach (var item in Inventory.Instance.Items)
        {
            AddToItemDatas(item);
        }
    }
    private void OnDisable()
    {
        ItemDatas.Clear();
    }

    public ItemData ConvertToItemData(Item item)
    {
        ItemData itemData = new ItemData();
        itemData.ItemID = item.ItemID;
        itemData.ItemName = item.ItemName;
        itemData.ItemIcon = item.ItemIcon;
        itemData.ItemCount = item.ItemCount;    
        return itemData;
    }

    public void AddToItemDatas(Item item)
    {
        ItemDatas.Add(ConvertToItemData(item));
    }

    public ItemData GetItemData(Item item)
    {
        ItemData data = new ItemData();
        data=ConvertToItemData(item);
        foreach(var itemData in ItemDatas)
        {
            if (data.ItemID == itemData.ItemID && itemData.ItemShowable)
            {
                return itemData;
            }
            
        }
        return null;
        
    }
    public ItemData GetItemData(ItemData data)
    {
        
        foreach (var itemData in ItemDatas)
        {
            
            if (itemData.ItemID == data.ItemID && itemData.ItemShowable)
            {
                return itemData;
            }

        }
        return null;

    }


    public void DecreaseItemDataCount(ItemData itemData)
    {
        itemData.ItemCount--;
        if (itemData.ItemCount<=0 && itemData.ItemShowable)
        {
            itemData.ItemShowable = false;
        }
    }
    public void IncreaseItemDataCount(ItemData itemData)
    {
        itemData.ItemCount++;
        if (itemData.ItemCount >= 0 && !itemData.ItemShowable)
        {
            itemData.ItemShowable = true;
        }
    }



}

public class ItemData
{
    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private bool _itemShowable=true;
    [SerializeField] private int _itemCount = 1;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public bool ItemShowable { get => _itemShowable; set => _itemShowable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public int ItemID { get => _itemID; set => _itemID = value; }
}
