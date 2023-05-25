using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class RecieptSlot : MonoBehaviour
{
    [SerializeField] private Item _selectedItem;
    private ItemData _selectedData;
    private Image _image;
    private Sprite _sprite;

    public Item SelectedItem { get => _selectedItem; set => _selectedItem = value; }
    public Image Image { get => _image; set => _image = value; }
    public ItemData SelectedData { get => _selectedData; set => _selectedData = value; }
    public Sprite Sprite { get => _sprite; set => _sprite = value; }

    private void OnDisable()
    {
        
        SelectedItem = null;
        Image.sprite = Sprite;
    }
    private void OnEnable()
    {
        SelectedItem=GetComponent<Item>();
    }

    private void Start()
    {
        Image = GetComponent<Image>();
        Sprite = Image.sprite;
        SelectedItem = gameObject.AddComponent<Item>();
    }

    public void OnSlotClicked()
    {
        OnOffMaterialSelectionPanel();
        AddToListAgain(SelectedData);
    }

    public void OnOffMaterialSelectionPanel()
    {
        MainPanel.Instance.MaterialSelectionPanel.GetComponent<MaterialSelection>().SelectedSlot = this;
        MainPanel.Instance.MaterialSelectionPanel.SetActive(!MainPanel.Instance.MaterialSelectionPanel.activeSelf);


    }

    public void SlotItemSelected(ItemData itemData)
    {
        Debug.Log(itemData.ItemName);
        SelectedItem.ItemIcon = itemData.ItemIcon;
        Image.sprite = SelectedItem.ItemIcon;
    }

    
    public void SetSelectedData(ItemData itemData)
    {
        SelectedData= CraftingManager.Instance.GetItemData(itemData);
    }

    public void AddToListAgain(ItemData itemData)
    {
        if (itemData != null)
        {
            CraftingManager.Instance.IncreaseItemDataCount(itemData);
        }
    }

    
    
}
