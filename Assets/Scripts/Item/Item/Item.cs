using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    #region ItemSO variables

    [SerializeField] private int _itemID;
    [SerializeField] private string _itemName;
    [SerializeField] private string _itemDescription;
    [SerializeField] private bool _itemStackable;
    [SerializeField] private int _itemCount = 1;
    [SerializeField] private Sprite _itemIcon;

    public string ItemName { get => _itemName; set => _itemName = value; }
    public string ItemDescription { get => _itemDescription; set => _itemDescription = value; }
    public bool ItemStackable { get => _itemStackable; set => _itemStackable = value; }
    public int ItemCount { get => _itemCount; set => _itemCount = value; }
    public Sprite ItemIcon { get => _itemIcon; set => _itemIcon = value; }
    public int ItemID { get => _itemID; set => _itemID = value; }

    #endregion

    [SerializeField] private GameObject _iconPanel;
    [SerializeField] private GameObject _countPanel;
    [SerializeField] private GameObject _generalPanel;
    [SerializeField] private GameObject _usagePanel;
    [SerializeField] private Transform _oldInventoryPanel;

    public GameObject IconPanel { get => _iconPanel; set => _iconPanel = value; }
    public GameObject CountPanel { get => _countPanel; set => _countPanel = value; }
    public GameObject GeneralPanel { get => _generalPanel; set => _generalPanel = value; }
    public GameObject UsagePanel { get => _usagePanel; set => _usagePanel = value; }
    public Transform OldInventoryPanel { get => _oldInventoryPanel; set => _oldInventoryPanel = value; }




    #region UnityCallBacks
    private void Start()
    {
        //if (!ItemStackable)
        //{
        //    ItemCount = 1;
        //    CountPanel.SetActive(false);
        //}
    }
    #endregion

    #region UICallbacks
    /// <summary>
    /// Item Button OnClickEvent Function
    /// </summary>
    public void OnClickItemButton()
    {
        UseItem();
    }

    /// <summary>
    /// Use Button OnClickEvent Function
    /// </summary>
    public void OnClickUseButton()
    {
        UseItem();
        SwitchGeneralUsagePanel();
    }

    /// <summary>
    /// Move Button OnClickEvent Function
    /// </summary>
    public void OnClickMoveButton()
    {
        MoveBetweenBackpackAndPocket();
        SwitchGeneralUsagePanel();

    }

    /// <summary>
    /// Drop Button OnClickEvent Function
    /// </summary>
    public void OnClickDropButton()
    {
        if (ItemCount <= 1)
        {

            DropItem(ItemCount);
        }
        else
        {
            InitializeDropPanel();
            SwitchGeneralUsagePanel();

        }
    }
    
    #endregion

    #region ScriptFunctions

    /// <summary>
    /// Use Item to its type on child classes its overriding.
    /// </summary>
    public virtual void UseItem()
    {
        //Look Child Classes
    }

    /// <summary>
    /// Item Move function. Takes target parent as a parameter.
    /// </summary>
    /// <param name="targetParent"></param>
    public virtual void MoveItem(Transform targetParent)
    {
        
    }

    /// <summary>
    /// Moves item backpack to pocket and reverse.
    /// </summary>
    public virtual void MoveBetweenBackpackAndPocket()
    {
        
        if (transform.parent.gameObject == MainPanel.Instance.BackpackPanel)
        {
            MoveItem(MainPanel.Instance.PocketPanel.transform);
        }
        else
        {
            MoveItem(MainPanel.Instance.BackpackPanel.transform);
        }
    }

    /// <summary>
    /// Destroys Item with count. If item is a stackable, it will decrease item counts.   
    /// </summary>
    /// <param name="count"></param>
    public void DropItem(int count)
    {
        Debug.Log("DropItem");
        DecreaseItemCount(count);
        if (ItemCount <= 0)
        {
            Inventory.Instance.RemoveItem(this);
        }

    }

    /// <summary>
    /// Increases item count. Used on stackable items
    /// </summary>
    /// <param name="count"></param>
    public void IncreaseItemCount(int count)
    {
        ItemCount += count;
        UpdateUIElements();
    }

    /// <summary>
    /// Decrease item count. Used on stackable items
    /// </summary>
    /// <param name="count"></param>
    public void DecreaseItemCount(int count)
    {
        ItemCount -= count;
        UpdateUIElements();
    }

    

    /// <summary>
    /// Updates UI Element. This can changes IconPanel sprite and CountPanel Text
    /// When count change tihs is working.
    /// </summary>
    public void UpdateUIElements()
    {
        IconPanel.GetComponent<Image>().sprite = ItemIcon;
        CountPanel.GetComponent<TextMeshProUGUI>().text = ItemCount + "";
    }


    /// <summary>
    /// Opens/Closes Usage panel menu
    /// Works when Right Clicked on UI element
    /// Also sets UsagePanel Position to mouse position.
    /// </summary>
    public void SwitchGeneralUsagePanel()
    {
        UsagePanel.SetActive(!UsagePanel.activeSelf);
        UsagePanel.transform.position = Input.mousePosition;
    }

    /// <summary>
    /// Initializes Drop Panel
    /// Whep Drop Button Pressed on Usage Panel this funciton works.
    /// </summary>
    public void InitializeDropPanel()
    {
        GameObject dropPanel = MainPanel.Instance.DropPanel;
        dropPanel.SetActive(true);
        ActionController ActionController = dropPanel.GetComponent<ActionController>();
        ActionController.Item = this;
        ActionController.CountText.text = ItemCount.ToString();
        ActionController.Slider.maxValue = ItemCount;
        ActionController.Slider.value = ItemCount;
        ActionController.NameText.text = ItemName;
    }   

    #endregion

   

}


