using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Unity.VisualScripting;
using TMPro;
using static UnityEngine.EventSystems.PointerEventData;

public class GUIItemMouseEvents : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,IPointerExitHandler/*,IBeginDragHandler,IDragHandler,IEndDragHandler*/
{
    public GameObject GeneralPanel;
    public GameObject UsagePanel;
    
    private TextMeshProUGUI _InfoPanelName;
    private TextMeshProUGUI _InfoPanelDescription;
    private ItemData _ItemData;
    private Item _Item;
    [HideInInspector]public Transform ParentAfterDrag;



    #region UnityCallbacks
    private void Start()
    {
        _Item = GetComponent<Item>();
        _ItemData = _Item.itemData;
        _InfoPanelName = GameObject.Find("InfoPanelName").GetComponent<TextMeshProUGUI>();
        _InfoPanelDescription = GameObject.Find("InfoPanelDescription").GetComponent<TextMeshProUGUI>();
    }
    #endregion

    #region PointerInterfaceCallbacks
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == InputButton.Right)
        {
            _Item.SwitchGeneralUsagePanel();

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _InfoPanelName.text = _ItemData.ItemName;
        _InfoPanelDescription.text = _ItemData.ItemDescription;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _InfoPanelName.text = "";
        _InfoPanelDescription.text = "";
    }

    #endregion


    //#region DragInterfaceCallbacks
    //public void OnBeginDrag(PointerEventData eventData)
    //{
    //    Debug.Log("Begin");
    //    GetComponent<Button>().interactable= false;
    //    _Item.oldInventorySlot = transform.parent.gameObject;
    //    ParentAfterDrag = transform.parent;
    //    GetComponentInParent<InventorySlot>().RemoveItem(_Item, InventorySlot.ItemOperation.Move);
    //    transform.SetParent( transform.root);
    //    transform.SetAsLastSibling();
    //    _Item.iconPanel.GetComponent<Image>().raycastTarget = false;

    //}
    //public void OnDrag(PointerEventData eventData)
    //{
    //    Debug.Log("OnDrag");
    //    transform.position= Input.mousePosition;

    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    Debug.Log("End");
    //    transform.SetParent( ParentAfterDrag);
    //    if (_Item.IsParentEquippedSlot())
    //    {
    //        _Item.EquipItemWithDrag();
    //    }
    //    else
    //    {
    //        _Item.UnEquipItemWithDrag();
    //    }
    //    GetComponentInParent<InventorySlot>().MoveItem(_Item);
    //    _Item.iconPanel.GetComponent<Image>().raycastTarget = true;
    //    GetComponent<Button>().interactable = true;
    //}

    //#endregion
}