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
    
    public void SetOutputDataID(int itemDataID,int deletedID)
    {
        OutputData.ItemID = addItem.FindItemWithID(itemDataID).ItemID;
        DeletedId.Add(deletedID);
        //Image.sprite = addItem.FindItemWithID(itemDataID).ItemIcon;
    }

    public void SetCraftedItem(int AddingItemID,int RemovingItemID)
    {
        addItem.AddItemWithID(AddingItemID);
        addItem.RemoveItemWithID(RemovingItemID);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Crafting Here
        CraftItem(OutputData.ItemID, RecieptSlots[0].SelectedData.ItemID);

        //List<ItemData> itemDatas = new List<ItemData>();
        //for (int i = 0; i < RecieptSlots.Length; i++)
        //{
        //    if (RecieptSlots[i].SelectedData != null)
        //    {
        //        itemDatas.Add(RecieptSlots[i].SelectedData);
                
        //    }
        //}
        //switch (itemDatas.Count)
        //{
        //    case 1:
        //        CraftingManager.Instance.CheckCraftableItem(itemDatas[0]);
        //        break;
        //    case 2:
        //        //CheckCraftableItem için 2 parametre kullanan fonksiyonu yazýlacak.
        //        //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1]);
        //        break; 
        //    case 3:
        //        //CheckCraftableItem için 3 parametre kullanan fonksiyonu yazýlacak.
        //        //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1],itemDatas[2]);
        //        break;
        //    case 4:
        //        //CheckCraftableItem için 4 parametre kullanan fonksiyonu yazýlacak.
        //        //CraftingManager.Instance.CheckCraftableItem(itemDatas[0],itemDatas[1],itemDatas[2],itemDatas[3]);
        //        break;

        //    default:
        //        break;
        //}
    }

    public void CraftItem(int AddingId,int RemovingID)
    {
        SetCraftedItem(AddingId, RemovingID);
        DeletedId.Remove(RemovingID);
    }
}
