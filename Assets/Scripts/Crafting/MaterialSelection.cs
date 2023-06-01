using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSelection : MonoBehaviour
{
    [SerializeField] private GameObject _UIElement;
    [SerializeField] private List<GameObject> _UIElements;
    private RecieptSlot _selectedSlot;

    public RecieptSlot SelectedSlot { get => _selectedSlot; set => _selectedSlot = value; }
    public GameObject UIElement { get => _UIElement; set => _UIElement = value; }
    public List<GameObject> UIElements { get => _UIElements; set => _UIElements = value; }

    private void OnEnable()
    {
        InstantiateUIItems();
    }
    private void OnDisable()
    {
        DestroyUIElements();
    }

    public void OnClickMaterialSelectionCloseButton()
    {
        //SelectedSlot.AddToListAgain(SelectedSlot.SelectedData);
        SelectedSlot.SelectedData=null;
        SelectedSlot.Image.sprite = SelectedSlot.Sprite;
        CraftingManager.Instance.InitializeCraft();
        MainPanel.Instance.MaterialSelectionPanel.SetActive(false);
    }

    public void InstantiateUIItems()
    {
        foreach (var item in CraftingManager.Instance.ItemDatas)
        {
            if (item.ItemCount > 0 && item.ItemShowable)
            {
                Item tmp = Instantiate(UIElement, transform).GetComponent<Item>();
                UpdateDatas(tmp, item);
                UpdateUIElement(tmp);
                UIElements.Add(tmp.gameObject);
            } 
            
        }
    }


    public Item UpdateDatas(Item item,ItemData itemdata)
    {
        item.ItemID= itemdata.ItemID;
        item.ItemCount= itemdata.ItemCount;
        item.ItemIcon= itemdata.ItemIcon;
        item.ItemName= itemdata.ItemName;
        return item;
    }

    public void UpdateUIElement(Item item)
    {
        item.IconPanel.GetComponent<Image>().sprite=item.ItemIcon;
    }


    public void DestroyUIElements()
    {
        foreach (var item in UIElements)
        {
            Destroy(item);
        }
    }


}
