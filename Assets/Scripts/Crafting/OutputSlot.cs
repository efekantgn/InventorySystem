using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OutputSlot : MonoBehaviour, IPointerClickHandler
{
    private Image _image;
    private Sprite _sprite;
    private ItemData _outputData;
    //private Item _craftedItem;
    public AddItem addItem;
    private RecieptSlot[] _recieptSlots;
    private List<int> _deletedId = new List<int>();

    public Image Image { get => _image; set => _image = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }


    private static OutputSlot _instance;
    public static OutputSlot Instance { get => _instance; set => _instance = value; }
    //public Item CraftedItem { get => _craftedItem; set => _craftedItem = value; }
    public RecieptSlot[] RecieptSlots { get => _recieptSlots; set => _recieptSlots = value; }
    public ItemData OutputData { get => _outputData; set => _outputData = value; }
    public List<int> DeletedId { get => _deletedId; set => _deletedId = value; }

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
        OutputData=new ItemData();
        RecieptSlots=FindObjectsOfType<RecieptSlot>();
        Image = GetComponent<Image>();
        Sprite = Image.sprite;
    }
    private void OnDisable()
    {
        Image.sprite = Sprite;
    }

    public void ResetRecipts()
    {
        foreach (var item in RecieptSlots)
        {
            item.SelectedData = null;
        }
    }
    public void SetOutputDataID()
    {
        OutputData.ItemID = -1;
        Image.sprite = Sprite;
    }

    public void SetOutputDataID(int itemDataID,int deletedID1)
    {
        Item item = addItem.FindItemWithID(itemDataID);
        OutputData.ItemID = item.ItemID;
        Image.sprite = item.ItemIcon;
        DeletedId.Add(deletedID1);
        
    }
    public void SetOutputDataID(int itemDataID, int deletedID1, int deletedID2)
    {
        Item item = addItem.FindItemWithID(itemDataID);
        OutputData.ItemID = item.ItemID;
        Image.sprite = item.ItemIcon;
        DeletedId.Add(deletedID1);
        DeletedId.Add(deletedID2);

    }
    public void SetOutputDataID(int itemDataID, int deletedID1, int deletedID2, int deletedID3)
    {
        Item item = addItem.FindItemWithID(itemDataID);
        OutputData.ItemID = item.ItemID;
        Image.sprite = item.ItemIcon;
        DeletedId.Add(deletedID1);
        DeletedId.Add(deletedID2);
        DeletedId.Add(deletedID3);

    }
    public void SetOutputDataID(int itemDataID, int deletedID1, int deletedID2, int deletedID3, int deletedID4)
    {
        Item item = addItem.FindItemWithID(itemDataID);
        OutputData.ItemID = item.ItemID;
        Image.sprite = item.ItemIcon;
        DeletedId.Add(deletedID1);
        DeletedId.Add(deletedID2);
        DeletedId.Add(deletedID3);
        DeletedId.Add(deletedID4);

    }

    public void SetCraftedItem(int AddingItemID,int RemovingItemID)
    {
        addItem.AddItemWithID(AddingItemID);
        addItem.RemoveItemWithID(RemovingItemID);
    }

    public void SetCraftedItem(int AddingItemID, int RemovingItemID, int RemovingItemID2)
    {
        addItem.AddItemWithID(AddingItemID);
        addItem.RemoveItemWithID(RemovingItemID);
        addItem.RemoveItemWithID(RemovingItemID2);
    }
    public void SetCraftedItem(int AddingItemID, int RemovingItemID, int RemovingItemID2, int RemovingItemID3)
    {
        addItem.AddItemWithID(AddingItemID);
        addItem.RemoveItemWithID(RemovingItemID);
        addItem.RemoveItemWithID(RemovingItemID2);
        addItem.RemoveItemWithID(RemovingItemID3);
    }
    public void SetCraftedItem(int AddingItemID, int RemovingItemID, int RemovingItemID2, int RemovingItemID3, int RemovingItemID4)
    {
        addItem.AddItemWithID(AddingItemID);
        addItem.RemoveItemWithID(RemovingItemID);
        addItem.RemoveItemWithID(RemovingItemID2);
        addItem.RemoveItemWithID(RemovingItemID3);
        addItem.RemoveItemWithID(RemovingItemID4);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Crafting Here


        //CraftItem(OutputData.ItemID, RecieptSlots[2].SelectedData.ItemID);
        List<ItemData> itemDatas = new List<ItemData>();
        for (int i = 0; i < RecieptSlots.Length; i++)
        {
            if (RecieptSlots[i].SelectedData != null)
            {
                itemDatas.Add(RecieptSlots[i].SelectedData);

            }
        }
        switch (itemDatas.Count)
        {
            case 1:
                CraftItem(OutputData.ItemID, itemDatas[0].ItemID);
                break;
            case 2:
                //CheckCraftableItem için 2 parametre kullanan fonksiyonu yazýlacak.
                CraftItem(OutputData.ItemID, itemDatas[0].ItemID, itemDatas[1].ItemID);
                break;
            case 3:
                //CheckCraftableItem için 3 parametre kullanan fonksiyonu yazýlacak.
                CraftItem(OutputData.ItemID, itemDatas[0].ItemID, itemDatas[1].ItemID, itemDatas[2].ItemID);

                break;
            case 4:
                //CheckCraftableItem için 4 parametre kullanan fonksiyonu yazýlacak.
                CraftItem(OutputData.ItemID, itemDatas[0].ItemID, itemDatas[1].ItemID, itemDatas[2].ItemID, itemDatas[3].ItemID);
                break;

            default:
                break;
        }
        EmptySlots(RecieptSlots);
        CraftingManager.Instance.ClearCraftingPanel();
        CraftingManager.Instance.InitializeCraftingPanel();

    }

    public void CraftItem(int AddingId,int RemovingID)
    {
        
        SetCraftedItem(AddingId, RemovingID);
        DeletedId.Remove(RemovingID);
    }
    public void CraftItem(int AddingId, int RemovingID,int RemovingID2)
    {

        SetCraftedItem(AddingId, RemovingID, RemovingID2);
        DeletedId.Remove(RemovingID);
    }
    public void CraftItem(int AddingId, int RemovingID, int RemovingID2, int RemovingID3)
    {
        SetCraftedItem(AddingId, RemovingID, RemovingID2, RemovingID3);
        DeletedId.Remove(RemovingID);
    }
    public void CraftItem(int AddingId, int RemovingID, int RemovingID2, int RemovingID3, int RemovingID4)
    {
        SetCraftedItem(AddingId, RemovingID, RemovingID2,RemovingID3,RemovingID4);
        DeletedId.Remove(RemovingID);
    }

    public void EmptySlots(RecieptSlot[] recieptSlot)
    {
        Image.sprite = Sprite;
        foreach (var slot in recieptSlot)
        {
            slot.ResetImage();
            slot.SelectedData = null;

        }
    }

    
}
