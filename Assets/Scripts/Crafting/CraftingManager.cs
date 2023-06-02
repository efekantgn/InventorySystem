using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    
    private List<ItemData> _itemDatas=new List<ItemData>();

    private Dictionary<ItemData, ItemData> _oneItemRecepies=new Dictionary<ItemData, ItemData>();
    private Dictionary<ItemData, List<ItemData>> _twoItemRecepies=new Dictionary<ItemData, List<ItemData>>();
    private Dictionary<ItemData, List<ItemData>> _threeItemRecepies=new Dictionary<ItemData, List<ItemData>>();
    private Dictionary<ItemData, List<ItemData>> _fourItemRecepies=new Dictionary<ItemData, List<ItemData>>();

    public List<ItemData> ItemDatas { get => _itemDatas; set => _itemDatas = value; }
    public Dictionary<ItemData, ItemData> OneItemRecepies { get => _oneItemRecepies; set => _oneItemRecepies = value; }
    public Dictionary<ItemData, List<ItemData>> TwoItemRecepies { get => _twoItemRecepies; set => _twoItemRecepies = value; }
    public Dictionary<ItemData, List<ItemData>> ThreeItemRecepies { get => _threeItemRecepies; set => _threeItemRecepies = value; }
    public Dictionary<ItemData, List<ItemData>> FourItemRecepies { get => _fourItemRecepies; set => _fourItemRecepies = value; }

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
        
        CSVReader.Instance.ReadCSV();
    }

    private void OnEnable()
    {
        InitializeCraftingPanel();


    }
    private void OnDisable()
    {
        ClearCraftingPanel();
        OutputSlot.Instance.ResetRecipts();
    }
    #endregion

    #region GetInventoryItemsToCraftingMenu

    public void InitializeCraftingPanel()
    {
        foreach (var item in Inventory.Instance.Items)
        {
            AddToItemDatas(item);
        }
    }

    public void ClearCraftingPanel()
    {
        ItemDatas.Clear();
    }

    public void InitializeCraft()
    {
        List<ItemData> itemDatas = new List<ItemData>();
        for (int i = 0; i < OutputSlot.Instance.RecieptSlots.Length; i++)
        {
            if (OutputSlot.Instance.RecieptSlots[i].SelectedData != null)
            {
                itemDatas.Add(OutputSlot.Instance.RecieptSlots[i].SelectedData);

            }
        }
        switch (itemDatas.Count)
        {
            case 1:
                CraftingManager.Instance.CheckOneItemRecipt(itemDatas[0]);
                break;
            case 2:
                //CheckCraftableItem için 2 parametre kullanan fonksiyonu yazýlacak.
                CraftingManager.Instance.CheckTwoItemRecipt(itemDatas[0],itemDatas[1]);
                break;
            case 3:
                //CheckCraftableItem için 3 parametre kullanan fonksiyonu yazýlacak.
                CraftingManager.Instance.CheckThreeItemRecipt(itemDatas[0],itemDatas[1],itemDatas[2]);
                break;
            case 4:
                //CheckCraftableItem için 4 parametre kullanan fonksiyonu yazýlacak.
                CraftingManager.Instance.CheckFourItemRecipt(itemDatas[0],itemDatas[1],itemDatas[2],itemDatas[3]);
                break;

            default:
                break;
        }
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

    #endregion


    public void CheckOneItemRecipt(ItemData itemData)
    {
        for (int i = 0; i < OneItemRecepies.Count; i++)
        {
            List<int> ids = new List<int>();
            ids.Add(OneItemRecepies.ElementAt(i).Value.ItemID);
            if (ids.Contains(itemData.ItemID))
            {
                OutputSlot.Instance.SetOutputDataID(OneItemRecepies.ElementAt(i).Key.ItemID, OneItemRecepies.ElementAt(i).Value.ItemID);

                break;
            }
            else
            {
                OutputSlot.Instance.SetOutputDataID();
            }

        }
    }

    public void CheckTwoItemRecipt(ItemData itemData,ItemData itemData2)
    {
        for (int i = 0; i < TwoItemRecepies.Count; i++)
        {
            List<int> ids = new List<int>();
            ids.Add(TwoItemRecepies.ElementAt(i).Value[0].ItemID);
            ids.Add(TwoItemRecepies.ElementAt(i).Value[1].ItemID);

            //Recipt1 TwoItemRecepiesin içindeki Material1 stünunda var mý?
            //if (ids.Contains(itemData.ItemID)
            //    && ids.Contains(itemData2.ItemID))
            //{
            //    OutputSlot.Instance.SetOutputDataID(TwoItemRecepies.ElementAt(i).Key.ItemID, TwoItemRecepies.ElementAt(i).Value[0].ItemID, TwoItemRecepies.ElementAt(i).Value[1].ItemID);

            //    break;
            //}
            //else
            //{
            //    OutputSlot.Instance.SetOutputDataID();
            //}
            if (ids.Contains(itemData.ItemID))
            {
                ids.Remove(itemData.ItemID);
                if (ids.Contains(itemData2.ItemID))
                {
                    ids.Remove(itemData2.ItemID);
                        
                    OutputSlot.Instance.SetOutputDataID(TwoItemRecepies.ElementAt(i).Key.ItemID, TwoItemRecepies.ElementAt(i).Value[0].ItemID, TwoItemRecepies.ElementAt(i).Value[1].ItemID);

                    break;
                    
                }
                else
                    OutputSlot.Instance.SetOutputDataID();
            }
            else
                OutputSlot.Instance.SetOutputDataID();


        }
    }
    public void CheckThreeItemRecipt(ItemData itemData, ItemData itemData2,ItemData itemData3)
    {
        ///itemDatalarýn idlerini liste içerisnde tutup conains ile buna bak ThreeItemRecepies.ElementAt(i).Value[0].ItemID
        
        for (int i = 0; i < ThreeItemRecepies.Count; i++)
        {
            List<int> ids= new List<int>();
            ids.Add(ThreeItemRecepies.ElementAt(i).Value[0].ItemID);
            ids.Add(ThreeItemRecepies.ElementAt(i).Value[1].ItemID);
            ids.Add(ThreeItemRecepies.ElementAt(i).Value[2].ItemID);

            //if (ids.Contains(itemData.ItemID)
            //    && ids.Contains(itemData2.ItemID)
            //    && ids.Contains(itemData3.ItemID))
            //{
            //    OutputSlot.Instance.SetOutputDataID(ThreeItemRecepies.ElementAt(i).Key.ItemID, ThreeItemRecepies.ElementAt(i).Value[0].ItemID, ThreeItemRecepies.ElementAt(i).Value[1].ItemID, ThreeItemRecepies.ElementAt(i).Value[2].ItemID);
            
            //    break;
            //}
            //else
            //{
            
            //    OutputSlot.Instance.SetOutputDataID();
            //}

            if (ids.Contains(itemData.ItemID))
            {
                ids.Remove(itemData.ItemID);
                if (ids.Contains(itemData2.ItemID))
                {
                    ids.Remove(itemData2.ItemID);
                    if (ids.Contains(itemData3.ItemID))
                    {
                        ids.Remove(itemData3.ItemID);
                        OutputSlot.Instance.SetOutputDataID(ThreeItemRecepies.ElementAt(i).Key.ItemID, ThreeItemRecepies.ElementAt(i).Value[0].ItemID, ThreeItemRecepies.ElementAt(i).Value[1].ItemID, ThreeItemRecepies.ElementAt(i).Value[2].ItemID);

                        break;
                    }
                    else
                        OutputSlot.Instance.SetOutputDataID();
                }
                else
                    OutputSlot.Instance.SetOutputDataID();
            }
            else
                OutputSlot.Instance.SetOutputDataID();

        }
    }
    public void CheckFourItemRecipt(ItemData itemData, ItemData itemData2, ItemData itemData3, ItemData itemData4)
    {
        for (int i = 0; i < FourItemRecepies.Count; i++)
        {
            List<int> ids = new List<int>();
            ids.Add(FourItemRecepies.ElementAt(i).Value[0].ItemID);
            ids.Add(FourItemRecepies.ElementAt(i).Value[1].ItemID);
            ids.Add(FourItemRecepies.ElementAt(i).Value[2].ItemID);
            ids.Add(FourItemRecepies.ElementAt(i).Value[3].ItemID);
            
            //if (ids.Contains(itemData.ItemID)
            //    && ids.Contains(itemData2.ItemID)
            //    && ids.Contains(itemData3.ItemID)
            //    && ids.Contains(itemData4.ItemID))
            //{
            //    OutputSlot.Instance.SetOutputDataID(FourItemRecepies.ElementAt(i).Key.ItemID, FourItemRecepies.ElementAt(i).Value[0].ItemID, FourItemRecepies.ElementAt(i).Value[1].ItemID, FourItemRecepies.ElementAt(i).Value[2].ItemID, FourItemRecepies.ElementAt(i).Value[3].ItemID);

            //    break;
            //}
            //else
            //{
            //    OutputSlot.Instance.SetOutputDataID();
            //}

            if (ids.Contains(itemData.ItemID))
            {
                ids.Remove(itemData.ItemID);
                if (ids.Contains(itemData2.ItemID))
                {
                    ids.Remove(itemData2.ItemID);
                    if (ids.Contains(itemData3.ItemID))
                    {
                        ids.Remove(itemData3.ItemID);
                        if (ids.Contains(itemData4.ItemID))
                        {
                            OutputSlot.Instance.SetOutputDataID(FourItemRecepies.ElementAt(i).Key.ItemID, FourItemRecepies.ElementAt(i).Value[0].ItemID, FourItemRecepies.ElementAt(i).Value[1].ItemID, FourItemRecepies.ElementAt(i).Value[2].ItemID);
                            break;

                        }
                        else
                            OutputSlot.Instance.SetOutputDataID();
                    }
                    else
                        OutputSlot.Instance.SetOutputDataID();
                }
                else
                    OutputSlot.Instance.SetOutputDataID();
            }
            else
                OutputSlot.Instance.SetOutputDataID();


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
