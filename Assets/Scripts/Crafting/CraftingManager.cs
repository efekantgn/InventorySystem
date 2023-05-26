using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public Sprite testSprite;
    public Sprite nullSprite;
    private List<ItemData> _itemDatas=new List<ItemData>();

    private Dictionary<ItemData, ItemData> _oneItemRecepies=new Dictionary<ItemData, ItemData>();

    public List<ItemData> ItemDatas { get => _itemDatas; set => _itemDatas = value; }
    public Dictionary<ItemData, ItemData> OneItemRecepies { get => _oneItemRecepies; set => _oneItemRecepies = value; }

    #region UnityCallbacks

    private static CraftingManager _instance;
    public static CraftingManager Instance { get => _instance; set => _instance = value; }
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

    private void Start()
    {
        //ItemData itemData = new ItemData();
        //itemData.SetItemDatas("sword", true, 1, testSprite, 0);
        //ItemData itemData2 = new ItemData();
        //itemData2.SetItemDatas("iron", true, 1, testSprite, 500);
        //OneItemRecepies.Add(itemData,itemData2);

        CSVReader.Instance.ReadCSV();
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
    #endregion

    #region GetInventoryItemsToCraftingMenu
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

    #endregion

    public void CheckCraftableItem(ItemData itemData)
    {
        for (int i = 0; i < OneItemRecepies.Count; i++)
        {
            Debug.Log(itemData.ItemID);
            if (itemData.ItemID == OneItemRecepies.ElementAt(i).Value.ItemID)
            {
                Debug.Log(OneItemRecepies.ElementAt(i).Key.ItemID + " crafted.");
                Debug.Log(OneItemRecepies.ElementAt(i).Value.ItemID + " Key used.");
                OutputSlot.Instance.SetOutputDataID(OneItemRecepies.ElementAt(i).Key.ItemID, OneItemRecepies.ElementAt(i).Value.ItemID);
                
                break;
            }
            else
            {
                //ItemData nullKey = new ItemData();
                //nullKey.SetItemDatas("", true, 1, nullSprite, -1);
                //OutputSlot.Instance.SetIcon(nullKey.ItemID);

                Debug.Log(itemData.ItemName + " not in Dictionary.");
                Debug.Log("Crafting failed");
            }

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

    public void SetItemDatas(string itemName, bool itemShowable, int itemCount, Sprite itemIcon, int itemID)
    {
        ItemName = itemName;
        ItemShowable = itemShowable;
        ItemCount = itemCount;
        ItemIcon = itemIcon;
        ItemID = itemID;
    }
    
}
